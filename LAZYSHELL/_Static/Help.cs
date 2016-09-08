using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

namespace LazyShell
{
    /// <summary>
    /// Class for converting an XML help file to a raw text file.
    /// </summary>
    public static class Help
    {
        /// <summary>
        /// Creates a help or readme document and opens the document for viewing.
        /// </summary>
        /// <param name="LazyShell_xml">The source XML data to use for the output.</param>
        /// <param name="readme">Indicates whether to output a readme.txt file. 
        /// If set to false, a LazyShell_txt.txt file based on the help document is created.</param>
        public static void CreateHelp(XmlDocument LazyShell_xml, bool readme)
        {
            var writer = new StringWriter();
            var main = LazyShell_xml.SelectSingleNode("LazyShell");
            writer.WriteLine(main.Attributes["title"].Value);
            //
            foreach (XmlNode node in main.ChildNodes)
            {
                if (node.Name == "Properties")
                {
                    writer.WriteLine("Version: " + node.Attributes["version"].Value);
                    writer.WriteLine("Date: " + node.Attributes["date"].Value);
                    writer.WriteLine("Home Page: " + node.Attributes["homepage"].Value);
                    writer.WriteLine("Written by " + node.Attributes["author"].Value);
                    writer.WriteLine("");
                }
                else
                {
                    var header = node.SelectSingleNode("header");
                    var body = node.SelectSingleNode("body");
                    writer.WriteLine("_______________________________________________________________________");
                    writer.WriteLine("");
                    if (header != null) writer.WriteLine(header.InnerText.ToUpper());
                    writer.WriteLine("_______________________________________________________________________");
                    writer.WriteLine("");
                    if (body != null)
                    {
                        string innerText = body.InnerText;
                        writer.WriteLine(Do.WordWrap(innerText, 71));
                        writer.WriteLine("");
                    }
                }
                if (node.Name == "Read")
                {
                    var introduction = node.SelectSingleNode("introduction");
                    if (introduction != null)
                        writer.WriteLine(Do.WordWrap(introduction.InnerText, 71));
                    writer.WriteLine("");
                    foreach (XmlNode precaution in node.SelectNodes("precaution"))
                    {
                        writer.WriteLine(Do.WordWrap(precaution.InnerText, 71, 3));
                        writer.WriteLine("");
                    }
                    var conclusion = node.SelectSingleNode("conclusion");
                    writer.WriteLine(Do.WordWrap(conclusion.InnerText, 71));
                    writer.WriteLine("");
                }
                if (node.Name == "Files")
                {
                    writer.WriteLine("");
                    foreach (XmlNode file in node.SelectNodes("file"))
                    {
                        var description = file.SelectSingleNode("description");
                        string name = file.Attributes["name"].Value;
                        writer.WriteLine("\"" + name + "\"");
                        writer.WriteLine("");
                        writer.WriteLine(Do.WordWrap(description.InnerText, 71));
                        writer.WriteLine("");
                        writer.WriteLine("");
                    }
                }
                else if (node.Name == "FAQ")
                {
                    foreach (XmlNode entry in node.SelectNodes("entry"))
                    {
                        var question = entry.SelectSingleNode("question");
                        var answer = entry.SelectSingleNode("answer");
                        writer.WriteLine("Q: " + Do.WordWrap(question.InnerText, 68, 3));
                        writer.WriteLine("A: " + Do.WordWrap(answer.InnerText, 68, 3));
                        writer.WriteLine("");
                    }
                    foreach (XmlNode editor in node.SelectNodes("../Editors/*[name() != 'header']"))
                    {
                        var faq = editor.SelectSingleNode("FAQ");
                        string name = editor.Attributes["title"].Value;
                        writer.WriteLine(String.Empty.PadLeft(name.Length, '_'));
                        writer.WriteLine(name.ToUpper());
                        writer.WriteLine(String.Empty.PadLeft(name.Length, '¯'));
                        foreach (XmlNode entry in faq.SelectNodes("entry"))
                        {
                            var question = entry.SelectSingleNode("question");
                            var answer = entry.SelectSingleNode("answer");
                            writer.WriteLine("Q: " + Do.WordWrap(question.InnerText, 68, 3));
                            writer.WriteLine("A: " + Do.WordWrap(answer.InnerText, 68, 3));
                            writer.WriteLine("");
                        }
                    }
                }
                else if (node.Name == "Glossary")
                {
                    foreach (XmlNode entry in node.SelectNodes("entry"))
                    {
                        var definition = entry.SelectSingleNode("definition");
                        writer.WriteLine("\"" + entry.Attributes["term"].Value + "\"");
                        writer.WriteLine(Do.WordWrap(definition.InnerText, 71));
                        writer.WriteLine("");
                    }
                }
                else if (node.Name == "Editors" && !readme)
                {
                    foreach (XmlNode editor in node.SelectNodes("*[name() != 'header']"))
                        HelpEditor(writer, editor);
                }
                else if (node.Name == "Other" && !readme)
                {
                    foreach (XmlNode editor in node.SelectNodes("*[name() != 'header']"))
                        HelpEditor(writer, editor);
                }
            }
            //
            if (readme)
            {
                File.WriteAllText("readme.txt", writer.ToString(), Encoding.UTF8);
                Process.Start("readme.txt");
            }
            else
            {
                if (!Directory.Exists("help"))
                    Directory.CreateDirectory("help");
                File.WriteAllText("help//LazyShell_txt.txt", writer.ToString(), Encoding.UTF8);
                Process.Start("help\\LazyShell_txt.txt");
            }
        }
        /// <summary>
        /// Converts an XML node associated with an editor component to text and writes the output to file.
        /// </summary>
        /// <param name="writer">The output stream to use.</param>
        /// <param name="editor">The XML node to analyze.</param>
        private static void HelpEditor(StringWriter writer, XmlNode editor)
        {
            string name = editor.Attributes["title"].Value;
            writer.WriteLine(String.Empty.PadLeft(name.Length, '_'));
            writer.WriteLine(name.ToUpper());
            writer.WriteLine(String.Empty.PadLeft(name.Length, '¯'));
            var description = editor.SelectSingleNode("description");
            if (description != null)
                writer.WriteLine(Do.WordWrap(description.InnerText, 71));
            foreach (XmlNode attribute in editor.SelectNodes("*[name() = 'attribute']"))
                HelpAttribute(writer, attribute, 3);
            HelpTooltips(writer, editor, 3);
            foreach (XmlNode section in editor.SelectNodes("*[@type = 'section']"))
                HelpSection(writer, section, 3);
            foreach (XmlNode subwindow in editor.SelectNodes("*[@type = 'subwindow']"))
                HelpSubwindow(writer, subwindow, 3);
        }
        /// <summary>
        /// Converts an XML node associated with an attribute to text and writes the output to file.
        /// </summary>
        /// <param name="writer">The output stream to use.</param>
        /// <param name="editor">The XML node to analyze.</param>
        private static void HelpAttribute(StringWriter writer, XmlNode attribute, int indent)
        {
            string pad = String.Empty.PadLeft(indent, ' ');
            writer.WriteLine(pad);
            writer.WriteLine(pad + Do.WordWrap(attribute.InnerText, 71, indent));
        }
        /// <summary>
        /// Converts an XML node associated with a section to text and writes the output to file.
        /// </summary>
        /// <param name="writer">The output stream to use.</param>
        /// <param name="editor">The XML node to analyze.</param>
        private static void HelpSection(StringWriter writer, XmlNode section, int indent)
        {
            string name = section.Attributes["title"].Value;
            string pad = String.Empty.PadLeft(indent, ' ');
            writer.WriteLine(pad);
            writer.WriteLine(pad + String.Empty.PadLeft(name.Length, '_'));
            writer.WriteLine(pad + name);
            writer.WriteLine(pad + String.Empty.PadLeft(name.Length, '¯'));
            var description = section.SelectSingleNode("description");
            if (description != null)
                writer.WriteLine(pad + Do.WordWrap(description.InnerText, 71, indent));
            HelpTooltips(writer, section, indent + 3);
            foreach (XmlNode subeditor in section.SelectNodes("*[@type = 'subeditor']"))
                HelpSubwindow(writer, section, indent + 3);
        }
        /// <summary>
        /// Converts an XML node associated with an editor's subwindow/owned form to text and writes the output to file.
        /// </summary>
        /// <param name="writer">The output stream to use.</param>
        /// <param name="editor">The XML node to analyze.</param>
        private static void HelpSubwindow(StringWriter writer, XmlNode subwindow, int indent)
        {
            string name = subwindow.Attributes["title"].Value;
            string pad = String.Empty.PadLeft(indent, ' ');
            writer.WriteLine(pad);
            writer.WriteLine(pad + String.Empty.PadLeft(name.Length, '_'));
            writer.WriteLine(pad + name.ToUpper());
            writer.WriteLine(pad + String.Empty.PadLeft(name.Length, '¯'));
            var description = subwindow.SelectSingleNode("description");
            if (description != null)
                writer.WriteLine(pad + Do.WordWrap(description.InnerText, 71, indent));
            foreach (XmlNode attribute in subwindow.SelectNodes("*[name() = 'attribute']"))
                HelpAttribute(writer, attribute, indent + 3);
            HelpTooltips(writer, subwindow, indent + 3);
            foreach (XmlNode section in subwindow.SelectNodes("*[@type = 'section']"))
                HelpSection(writer, section, indent + 3);
        }
        /// <summary>
        /// Converts an XML node associated with a control tooltip to text and writes the output to file.
        /// </summary>
        /// <param name="writer">The output stream to use.</param>
        /// <param name="editor">The XML node to analyze.</param>
        private static void HelpTooltips(StringWriter writer, XmlNode parent, int indent)
        {
            string pad = String.Empty.PadLeft(indent, ' ');
            var tooltips = parent.SelectNodes("tooltip");
            if (tooltips.Count > 0)
            {
                writer.WriteLine(pad);
                writer.WriteLine(pad + "***TOOLTIPS***");
            }
            foreach (XmlNode tooltip in tooltips)
            {
                var title = tooltip.SelectSingleNode("title");
                var description = tooltip.SelectSingleNode("description");
                writer.WriteLine(pad + "[" + title.InnerText + "]");
                writer.WriteLine(pad + "  " + Do.WordWrap(description.InnerText, 71, indent + 2));
            }
        }
    }
}
