using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LazyShell.Properties;
using LazyShell.EventScripts;
using LazyShell.Undo;
using WeifenLuo.WinFormsUI.Docking;

namespace LazyShell.Audio
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        public int Index
        {
            get { return (int)trackNum.Value; }
            set { trackNum.Value = value; }
        }
        public ElementType Type
        {
            get
            {
                if (soundType.SelectedIndex == 0)
                    return ElementType.SPCTrack;
                else if (soundType.SelectedIndex == 1)
                    return ElementType.SPCEvent;
                else
                    return ElementType.SPCBattle;
            }
            set
            {
                if (value == ElementType.SPCTrack)
                    soundType.SelectedIndex = 0;
                else if (value == ElementType.SPCEvent)
                    soundType.SelectedIndex = 1;
                else
                    soundType.SelectedIndex = 2;
            }
        }
        public SoundPlayer SoundPlayer;
        public SPC[] SPCs { get; set; }
        public SPC SPC
        {
            get { return SPCs[Index]; }
            set { SPCs[Index] = value; }
        }
        private Settings settings;
        private PreviewerForm previewerForm;
        private EditLabel labelWindow;
        private SamplesForm samplesForm;
        public TrackViewerForm TrackViewerForm { get; set; }
        public ScoreViewerForm ScoreViewerForm { get; set; }
        public InstrumentsForm InstrumentsForm { get; set; }
        public ScoreWriterForm ScoreWriterForm { get; set; }
        private FindReferences findReferencesForm;
        private delegate void FindReferencesFunction(TreeView treeView);
        private CheckBox[] activeChannels
        {
            get { return TrackViewerForm.ActiveChannels; }
            set { TrackViewerForm.ActiveChannels = value; }
        }
        private int mouseOverChannel
        {
            get { return TrackViewerForm.MouseOverChannel; }
            set { TrackViewerForm.MouseOverChannel = value; }
        }
        private List<Staff> staffs
        {
            get { return ScoreViewerForm.Staffs; }
            set { ScoreViewerForm.Staffs = value; }
        }

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            CreateHelperForms();
            CreateShortcuts();
            InitializeVariables();
            InitializeNavigators();
            InitializeForms();
            LoadProperties();
            //
            SetFreeBytesLabel();
            //
            this.History = new History(this, trackName, trackNum);
        }

        #region Methods

        public void LoadProperties()
        {
            this.Updating = true;
            //
            importMML.Enabled = Type == ElementType.SPCTrack;
            exportMML.Enabled = Type == ElementType.SPCTrack;

            // Reload properties in forms
            if (Type == ElementType.SPCTrack)
            {
                SPC.CreateNotes();
                InstrumentsForm.LoadProperties();
                ScoreViewerForm.LoadProperties();
                toggleInstruments.Enabled = true;
                toggleScoreViewer.Enabled = true;
                toggleTrackViewer.Enabled = true;
            }
            else
            {
                //InstrumentsForm.Hide();
                //ScoreViewerForm.Hide();
                toggleInstruments.Enabled = false;
                toggleScoreViewer.Enabled = false;
                toggleTrackViewer.Enabled = true;
            }
            TrackViewerForm.LoadProperties();
            //
            RefreshPictures();
            //
            this.Updating = false;
        }

        // Initialization
        private void InitializeVariables()
        {
            settings = Settings.Default;
            SoundPlayer = new SoundPlayer();
        }
        private void InitializeNavigators()
        {
            this.Updating = true;
            //
            if (settings.RememberLastIndex)
                Type = (ElementType)settings.LastSPCType;
            else
                Type = ElementType.SPCTrack;
            //
            this.Updating = false;

            SetListControls();

            this.Updating = true;
            //
            if (settings.RememberLastIndex)
            {
                if (settings.LastSPC == 0)
                    settings.LastSPC = 1;
                Index = settings.LastSPC;
            }
            trackName.SelectedIndex = Index;
            //
            this.Updating = false;
        }
        private void InitializeForms()
        {
            // Create new instances of forms
            InstrumentsForm = new InstrumentsForm(this);
            TrackViewerForm = new TrackViewerForm(this);
            ScoreViewerForm = new ScoreViewerForm(this);
            ScoreWriterForm = new ScoreWriterForm(this);
            samplesForm = new SamplesForm();

            // Assign toggle buttons
            InstrumentsForm.ToggleButton = toggleInstruments;
            TrackViewerForm.ToggleButton = toggleTrackViewer;
            ScoreViewerForm.ToggleButton = toggleScoreViewer;
            ScoreWriterForm.ToggleButton = toggleScoreWriter;
            samplesForm.ToggleButton = toggleSamples;

            // Assign owner forms
            samplesForm.Owner = this;
            InstrumentsForm.Show(dockPanel, DockState.DockRight);
            TrackViewerForm.Show(dockPanel, DockState.DockRight);
            ScoreViewerForm.Show(dockPanel, DockState.Document);
            ScoreWriterForm.Show(dockPanel, DockState.Document);
            samplesForm.Show(ScoreViewerForm.Pane, DockAlignment.Bottom, 0.30);
        }
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip1, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip1, Keys.F1, helpTips);
        }
        private void CreateHelperForms()
        {
            labelWindow = new EditLabel(trackName, trackNum, "Songs", true);
            new ToolTipLabel(this, null, helpTips);
        }

        //
        public void SetFreeBytesLabel()
        {
            int left = 0;
            if (Type == ElementType.SPCTrack)
                left = Model.FreeSPCTrackSpace(false);
            else if (Type == ElementType.SPCEvent)
                left = Model.FreeSPCEventSpace(false);
            else
                left = Model.FreeSPCBattleSpace(false);
            //
            freeSpace.Text = left.ToString() + " available bytes";
            freeSpace.ForeColor = left < 0 ? Color.Red : SystemColors.ControlText;
        }
        private void SetListControls()
        {
            this.Updating = true;
            //
            trackName.Items.Clear();
            if (Type == ElementType.SPCTrack)
            {
                SPCs = Model.SPCs;
                trackName.Items.AddRange(Lists.Numerize(Lists.SPCTracks));
                trackNum.Minimum = 1;
                trackNum.Value = 1;
				trackName.SelectedIndex = 1;
                labelWindow.SetElement("Songs");
            }
            else if (Type == ElementType.SPCEvent)
            {
                SPCs = Model.SPCEvent;
                trackName.Items.AddRange(Lists.Numerize(Lists.SPCEventSounds));
                trackNum.Minimum = 0;
                trackNum.Value = 0;
				trackName.SelectedIndex = 0;
                labelWindow.SetElement("Sound FX (Event)");
            }
            else
            {
                SPCs = Model.SPCBattle;
                trackName.Items.AddRange(Lists.Numerize(Lists.SPCBattleSounds));
                trackNum.Minimum = 0;
                trackNum.Value = 0;
				trackName.SelectedIndex = 0;
                labelWindow.SetElement("Sound FX (Battle)");
            }
            trackNum.Maximum = SPCs.Length - 1;
            //
            this.Updating = false;
        }
        private void SaveLastLoadedIndex()
        {
            if (settings.RememberLastIndex)
            {
                settings.LastSPCType = (int)Type;
                settings.LastSPC = Index;
            }
        }
        public void RefreshPictures()
        {
            TrackViewerForm.Picture.Invalidate();
            ScoreViewerForm.Picture.Invalidate();
        }

        //
        private void FindReferences(TreeView treeView)
        {
            if (this.Type == ElementType.SPCTrack) // SPC Tracks
            {
                // Search through areas
                var areaResults = new TreeNode();
                foreach (var area in Areas.Model.Areas)
                {
                    if (area.EventTriggers.StartMusic == this.Index)
                    {
                        var result = new TreeNode(Lists.Numerize(Lists.Areas, area.Index));
                        result.Tag = area;
                        areaResults.Nodes.Add(result);
                    }
                }
                if (areaResults.Nodes.Count > 0)
                {
                    areaResults.Text = "AREAS — found " + areaResults.Nodes.Count + " results";
                    treeView.Nodes.Add(areaResults);
                }
                // Search through event scripts
                var eventScriptResults = new TreeNode();
                foreach (var eventScript in EventScripts.Model.EventScripts)
                {
                    foreach (var command in eventScript.Commands)
                    {
                        byte opcode = command.Opcode;
                        byte param1 = command.Param1;
                        if (opcode == 0x90 || opcode == 0x91 || opcode == 0x92 ||
                            (opcode == 0xFD && param1 == 0x9E))
                        {
                            int pointToSound = 0;
                            if (opcode != 0xFD)
                                pointToSound = command.Param1;
                            else
                                pointToSound = command.Param2;
                            // If points to this SPC, create a node from result and add to the parent node
                            if (pointToSound == this.Index)
                            {
                                var result = command.Node;
                                result.Tag = command;
                                eventScriptResults.Nodes.Add(result);
                            }
                        }
                    }
                }
                if (eventScriptResults.Nodes.Count > 0)
                {
                    eventScriptResults.Text = "EVENT SCRIPTS — found " + eventScriptResults.Nodes.Count + " results";
                    treeView.Nodes.Add(eventScriptResults);
                }
                // Search through animation scripts
            }
            else if (this.Type == ElementType.SPCEvent) // SPC Event Sounds
            {
                // Search through event scripts
                var eventScriptResults = new TreeNode();
                foreach (var eventScript in EventScripts.Model.EventScripts)
                {
                    foreach (var command in eventScript.Commands)
                    {
                        byte opcode = command.Opcode;
                        byte param1 = command.Param1;
                        if (opcode == 0x9C || opcode == 0x9D || opcode == 0x92 ||
                            (opcode == 0xFD && (param1 == 0x9C || param1 == 0x9D)))
                        {
                            int pointToSound = 0;
                            if (opcode != 0xFD)
                                pointToSound = command.Param1;
                            else
                                pointToSound = command.Param2;
                            // If points to this SPC, create a node from result and add to the parent node
                            if (pointToSound == this.Index)
                            {
                                var result = command.Node;
                                result.Tag = command;
                                eventScriptResults.Nodes.Add(result);
                            }
                        }
                        else if (command.QueueTrigger && command.Queue != null)
                        {
                            if (opcode == 0x9C || opcode == 0x9D || (opcode == 0xFD && param1 == 0x9E))
                            {
                                int pointToSound = 0;
                                if (opcode != 0xFD)
                                    pointToSound = command.Param1;
                                else
                                    pointToSound = command.Param2;
                                if (pointToSound == this.Index)
                                {
                                    var result = command.Node;
                                    result.Tag = command;
                                    eventScriptResults.Nodes.Add(result);
                                }
                            }
                        }
                    }
                }
                if (eventScriptResults.Nodes.Count > 0)
                {
                    eventScriptResults.Text = "EVENT SCRIPTS — found " + eventScriptResults.Nodes.Count + " results";
                    treeView.Nodes.Add(eventScriptResults);
                }
            }
            else if (this.Type == ElementType.SPCBattle) // SPC Battle Sounds
            {
                // Search through animation scripts
            }
        }
        public void WriteToROM(bool showWarning)
        {
            samplesForm.WriteToROM();
            samplesForm.Modified = false;
            //
            int offset = 0x045526;
            if (Model.FreeSPCTrackSpace(showWarning) >= 0)
                for (int i = 0; i < Model.SPCs.Length; i++)
                    Model.SPCs[i].WriteToROM(ref offset);
            offset = 0x042C26;
            if (Model.FreeSPCEventSpace(showWarning) >= 0)
                for (int i = 0; i < Model.SPCEvent.Length; i++)
                    Model.SPCEvent[i].WriteToROM(ref offset);
            offset = 0x044226;
            if (Model.FreeSPCBattleSpace(showWarning) >= 0)
                for (int i = 0; i < Model.SPCBattle.Length; i++)
                    Model.SPCBattle[i].WriteToROM(ref offset);
            this.Modified = false;
        }

        //
        private void PlayNote(Note note)
        {
            if (note.Rest || !note.IsNote)
                return;
            var sample = Model.BRRSamples[note.Sample];
            byte[] wav = BRR.BRRToWAV(sample.Sample, sample.Rate);
            Do.Play(SoundPlayer, wav, false);
        }

        // Import / Export
        public bool ImportSPCScript(ref List<Command> sourceCommands)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import SPC script";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return false;
            string path = openFileDialog.FileName;
            TextReader tr = new StreamReader(path);
            string[] strings = Parser.Commands;
            for (int i = 0; i < strings.Length; i++)
                strings[i] = Regex.Replace(strings[i], "\\{[^^]+", "");
            List<Command> commands = new List<Command>();
            int octave = 6;
            bool octaveIsSet = false;
            string temp = "";
            string error = "";
            int lineNumber = 1;
            while (tr.Peek() != -1)
            {
                try
                {
                    int opcode = -1;
                    int parameter1 = 0;
                    int parameter2 = 0;
                    int parameter3 = 0;
                    int length = 0;
                    byte[] command;
                    string line = tr.ReadLine();
                    if (line == "") // just skip line if empty, no errors
                        continue;
                    temp = line;
                    #region Notes
                    if (line.StartsWith("Note "))
                    {
                        line = line.Remove(0, 5); // remove "Note "
                        Beat beat = Beat.Empty;
                        Pitch pitch = Pitch.C;
                        int duration = 0;
                        // see if it's a note to play
                        if (line.StartsWith("play: "))
                        {
                            line = line.Remove(0, 6); // remove "play: "
                            bool Ab = line.StartsWith("Ab");
                            // Find pitch based on letter key
                            if (line.StartsWith("Ab")) { pitch = Pitch.Gs; line = line.Remove(0, 2); }
                            else if (line.StartsWith("A#") || line.StartsWith("Bb")) { pitch = Pitch.As; line = line.Remove(0, 2); }
                            else if (line.StartsWith("A")) { pitch = Pitch.A; line = line.Remove(0, 1); }
                            else if (line.StartsWith("B") || line.StartsWith("Cb")) { pitch = Pitch.B; line = line.Remove(0, 1); }
                            else if (line.StartsWith("C#") || line.StartsWith("Db")) { pitch = Pitch.Cs; line = line.Remove(0, 2); }
                            else if (line.StartsWith("C")) { pitch = Pitch.C; line = line.Remove(0, 1); }
                            else if (line.StartsWith("D#") || line.StartsWith("Eb")) { pitch = Pitch.Ds; line = line.Remove(0, 2); }
                            else if (line.StartsWith("D")) { pitch = Pitch.D; line = line.Remove(0, 1); }
                            else if (line.StartsWith("E#")) { pitch = Pitch.F; line = line.Remove(0, 2); }
                            else if (line.StartsWith("E") || line.StartsWith("Fb")) { pitch = Pitch.E; line = line.Remove(0, 1); }
                            else if (line.StartsWith("F#") || line.StartsWith("Gb")) { pitch = Pitch.Fs; line = line.Remove(0, 2); }
                            else if (line.StartsWith("F")) { pitch = Pitch.F; line = line.Remove(0, 1); }
                            else if (line.StartsWith("G#")) { pitch = Pitch.Gs; line = line.Remove(0, 2); }
                            else if (line.StartsWith("G")) { pitch = Pitch.G; line = line.Remove(0, 1); }
                            // Check if octave set in note (only 9 octaves)
                            if (Regex.IsMatch(line[0].ToString(), "[0-8]"))
                            {
                                // if different from current octave, change octave
                                byte value = Convert.ToByte(line[0].ToString(), 10);
                                // Only if not Ab0, b/c Ab0 doesn't exist
                                if (Ab && octave != 0)
                                    octave--;
                                else if (Ab && octave == 0)
                                    continue; // Skip because Ab0 not valid note, thus not valid command
                                if (value != octave || !octaveIsSet)
                                {
                                    if (!octaveIsSet) // if first note, must set current octave
                                    {
                                        command = new byte[] { 0xC6, value };
                                        octave = value;
                                        octaveIsSet = true;
                                    }
                                    else if (value == octave + 1)
                                    {
                                        command = new byte[] { 0xC4 };
                                        octave++;
                                    }
                                    else if (value == octave - 1)
                                    {
                                        command = new byte[] { 0xC5 };
                                        octave--;
                                    }
                                    else
                                    {
                                        command = new byte[] { 0xC6, value };
                                        octave = value;
                                    }
                                    if (Type == ElementType.SPCTrack)
                                        commands.Add(new Command(command, (SPCTrack)this.SPC, mouseOverChannel));
                                    else
                                        commands.Add(new Command(command, (SPCSound)this.SPC, mouseOverChannel));
                                }
                                line = line.Remove(0, 1);
                            }
                            line = line.Remove(0, 2); // remove ", "
                        }
                        else if (line.StartsWith("rest, "))
                        {
                            pitch = Pitch.Rest;
                            line = line.Remove(0, 6); // remove "rest, "
                        }
                        else if (line.StartsWith("tie, "))
                        {
                            pitch = Pitch.Tie;
                            line = line.Remove(0, 5); // remove "tie, "
                        }
                        // now check if beat or fixed duration
                        if (line.StartsWith("beat: "))
                        {
                            line = line.Remove(0, 6);
                            switch (line)
                            {
                                case "whole": beat = Beat.Whole; break;
                                case "half.": beat = Beat.HalfDotted; break;
                                case "half": beat = Beat.Half; break;
                                case "quarter.": beat = Beat.QuarterDotted; break;
                                case "quarter": beat = Beat.Quarter; break;
                                case "8th.": beat = Beat.EighthDotted; break;
                                case "triplet quarter": beat = Beat.QuarterTriplet; break;
                                case "8th": beat = Beat.Eighth; break;
                                case "triplet 8th": beat = Beat.EighthTriplet; break;
                                case "16th": beat = Beat.Sixteenth; break;
                                case "triplet 16th": beat = Beat.SixteenthTriplet; break;
                                case "32nd": beat = Beat.ThirtySecond; break;
                                case "64th": beat = Beat.SixtyFourth; break;
                                default: break;
                            }
                        }
                        else if (line.StartsWith("duration: "))
                        {
                            line = line.Remove(0, 10);
                            duration = Convert.ToByte(line, 10);
                            // check if duration a standard beat length
                            for (int i = 0; i < 13; i++)
                                if (duration == Model.ROM[0x042304 + i])
                                    beat = (Beat)i;
                        }
                        if (beat == Beat.Empty)
                        {
                            opcode = 0xB6 + (int)pitch;
                            parameter1 = duration;
                        }
                        else
                            opcode = (int)beat * 14 + (int)pitch;
                    }
                    #endregion
                    #region Commands
                    else
                    {
                        // look through interpreter strings for legitimate opcodes
                        for (int i = 0xC4; i < strings.Length; i++)
                        {
                            if (strings[i] != "" && line.StartsWith(strings[i]))
                            {
                                opcode = i;
                                line = line.Remove(0, strings[i].Length);
                                break;
                            }
                        }
                        // if line has no matches, check if raw opcode in {}
                        if (opcode == -1 && line.Length >= 4 && line.StartsWith("{") && line.EndsWith("}"))
                        {
                            // remove {} and -
                            line = line.Replace("{", "");
                            line = line.Replace("}", "");
                            string[] parameters = line.Split(new char[] { '-' });
                            line = line.Replace("-", "");
                            length = line.Length / 2;
                            opcode = Convert.ToByte(parameters[0], 16);
                            if (parameters.Length > 1)
                                parameter1 = Convert.ToByte(parameters[1], 16);
                            if (parameters.Length > 2)
                                parameter2 = Convert.ToByte(parameters[2], 16);
                            if (parameters.Length > 3)
                                parameter3 = Convert.ToByte(parameters[3], 16);
                        }
                        // if no matches and not raw opcode, not a legitimate command
                        else if (opcode == -1)
                            continue;
                        // otherwise, it is a legitimate command, so continue reading line
                        #region Opcode Interpreter
                        else
                        {
                            // get array of strings for each individual parameter
                            string[] parameters = line.Split(new char[] { ',' });
                            switch (opcode)
                            {
                                case 0xCD: // Play sound
                                case 0xCE: // Play sound
                                case 0xDE: // Set instrument
                                    line = line.Replace("{", "");
                                    line = line.Replace("}", "");
                                    line = line.Remove(3); // rest not needed, just need sound effect index
                                    parameter1 = Bits.GetInt32(ref line);
                                    break;
                                case 0xC4: // Octave up
                                    octave++; break;
                                case 0xC5: // Octave down
                                    octave--; break;
                                case 0xC6: // Octave = 
                                    parameter1 = Bits.GetInt32(ref line);
                                    octave = parameter1;
                                    octaveIsSet = true;
                                    break;
                                case 0xC8: // Noise on, channels = 
                                case 0xD1: // Beat duration = 
                                case 0xD4: // Start loop, count = 
                                case 0xD9: // ADSR attack = 
                                case 0xDA: // ADSR decay = 
                                case 0xDB: // ADSR sustain = 
                                case 0xDC: // ADSR release = 
                                case 0xDD: // Sample length = 
                                case 0xE0: // Sample fadeout = 
                                case 0xE2: // Volume = 
                                case 0xE7: // Speaker balance = 
                                case 0xF6: // Portamento on, length = 
                                    parameter1 = Bits.GetInt32(ref line);
                                    break;
                                case 0xDF: // Noise transpose, pitch = 
                                    parameter1 = Bits.GetInt32(ref parameters[0]);
                                    parameter2 = Bits.GetInt32(ref parameters[1]);
                                    if (parameter1 < 0)
                                        parameter1 += 0x20;
                                    parameter1 |= parameter2 << 5;
                                    break;
                                case 0xE4: // Volume slide, duration = 
                                case 0xE5: // Portamento, duration = 
                                    parameter1 = Bits.GetInt32(ref parameters[0]);
                                    parameter2 = (byte)((sbyte)Bits.GetInt32(ref parameters[1]));
                                    break;
                                case 0xE8: // Speaker balance shift, duration = 
                                case 0xE9: // Speaker balance pansweep, duration = 
                                    parameter1 = Convert.ToByte(parameters[0], 10);
                                    parameter2 = (byte)Bits.GetInt32(ref parameters[1]);
                                    break;
                                case 0xF0: // Tremolo, rate = 
                                case 0xF1: // Vibrato, rate = 
                                case 0xF4: // Growling, roughness = 
                                    parameter1 = Bits.GetInt32(ref parameters[0]);
                                    parameter2 = Bits.GetInt32(ref parameters[1]);
                                    if (opcode == 0xF1)
                                        parameter3 = Bits.GetInt32(ref parameters[2]);
                                    break;
                                case 0xCF: // Transpose 1/16 pitch = 
                                case 0xE3: // Volume shift, amount = 
                                case 0xEC: // Transpose 1/4 pitch 1 = 
                                case 0xED: // Transpose 1/4 pitch 2 = 
                                case 0xF2: // Beat duration, change = 
                                    parameter1 = (byte)((sbyte)Bits.GetInt32(ref line)); // signed byte
                                    break;
                                case 0xFC: // Reverb, delay = 
                                    parameter1 = Bits.GetInt32(ref parameters[0]);
                                    parameter2 = Bits.GetInt32(ref parameters[1]);
                                    parameter3 = Bits.GetInt32(ref parameters[2]);
                                    break;
                                default: break;
                            }
                        }
                        #endregion
                    }
                    #endregion
                    // create the command data
                    length = ScriptEnums.CommandLengths[opcode];
                    command = new byte[length];
                    if (length > 0)
                        command[0] = (byte)opcode;
                    if (length > 1)
                        command[1] = (byte)parameter1;
                    if (length > 2)
                        command[2] = (byte)parameter2;
                    if (length > 3)
                        command[3] = (byte)parameter3;
                    if (Type == ElementType.SPCTrack)
                        commands.Add(new Command(command, (SPCTrack)this.SPC, mouseOverChannel));
                    else
                        commands.Add(new Command(command, (SPCSound)this.SPC, mouseOverChannel));
                }
                catch (Exception ex)
                {
                    error += "Error reading line #" + lineNumber + " (\"" + temp + "\"). " + ex.Message + "\n";
                }
                lineNumber++;
            }
            if (error == "")
                MessageBox.Show("Import successful.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                new NewMessageBox("LAZY SHELL", "There were some errors importing the channel script.", error, "", MessageIcon.Warning).ShowDialog();
            tr.Close();
            sourceCommands = commands;
            return true;
        }
        public bool ImportMMLScript(List<Command>[] sourceChannels, bool[] activeChannels)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import Music Macro Language script";
            openFileDialog.Filter = "MML files (*.mml;*.txt)|*.mml;*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return false;
            //
            PickNativeSPC pickNativeSPC = new PickNativeSPC();
            if (pickNativeSPC.ShowDialog() == DialogResult.Cancel)
                return false;
            NativeSPC nativeFormat = (NativeSPC)pickNativeSPC.Tag;
            //
            string path = openFileDialog.FileName;
            BinaryFormatter b = new BinaryFormatter();
            // clean up unnecessary junk and create script text
            string script = new StreamReader(path).ReadToEnd();
            script = Regex.Replace(script, "[ \t]", ""); // remove all spaces, tabs
            script = Regex.Replace(script, "\r", "\n"); // replace these with newline to simplify
            script = Regex.Replace(script, "\n+", "\n"); // remove empty newlines
            script = Regex.Replace(script, ";[^\n]+\n", ""); // remove all comments
            script = Regex.Replace(script, ";\n", ""); // remove all empty comment lines
            // initialize variables
            List<Command>[] channels = new List<Command>[sourceChannels.Length];
            List<int> foundPercussives = new List<int>();
            List<int> foundInstruments = new List<int>();
            List<int> newInstruments = new List<int>();
            int channel = -1;
            int globalVol = -1;
            string temp = "";
            string error = "";
            int lineNumber = 1;
            bool triplet = false;
            bool writingLabel = false;
            bool writingLoop = false;
            int label = -1;
            int currentNestedLoop = -1; // the current nested loop
            int setTicks = -1;
            int lastTicks = -1;
            int octave = 4;
            // percussive variables
            Pitch pitchIndex = 0;
            bool percussiveMode = false;
            Pitch percussivePitch = Pitch.A;
            Pitch lastPitch = Pitch.A;
            Stack<int> loopCount = new Stack<int>();
            List<Command> lastLoop = null;
            List<Command>[] labels = new List<Command>[1000];
            // first create percussive list
            List<Percussive> percussives = new List<Percussive>();
            if (nativeFormat == NativeSPC.SMWLevel || nativeFormat == NativeSPC.SMWOverworld)
            {
                percussives.Add(new Percussive(0, 18, 64, 100, 127));
                percussives.Add(new Percussive(1, 109, 64, 100, 127));
                percussives.Add(new Percussive(2, 51, 64, 100, 127));
                percussives.Add(new Percussive(3, 52, 64, 100, 127));
                percussives.Add(new Percussive(4, 53, 64, 100, 127));
                percussives.Add(new Percussive(5, 67, 64, 100, 127));
                percussives.Add(new Percussive(6, 67, 64, 100, 127));
                percussives.Add(new Percussive(7, 51, 64, 100, 127));
                percussives.Add(new Percussive(8, 51, 64, 100, 127));
                //
                script = script.Replace("$ED$80$6D$2B\n" + "$ED$80$7D$00\n" + "$F0", "");
                script = script.Replace("$ED$80$6D$68\n" + "$ED$80$7D$00\n" + "$F0", "");
            }
            //
            while (script != "")
            {
                try
                {
                    int opcode = -1;
                    int parameter1 = 0;
                    int parameter2 = 0;
                    int parameter3 = 0;
                    int length = 0;
                    byte[] command;
                    //
                    temp = script;
                    // read to end of line
                    // at beginning of loop, b/c must reset after each command
                    #region Notes
                    if (script.StartsWith("#") || script.StartsWith("{Ch"))
                    {
                        if (script.StartsWith("#"))
                        {
                            script = script.Remove(0, 1);
                            channel = Bits.GetInt32(ref script);
                        }
                        else
                        {
                            script = script.Remove(0, 3);
                            channel = Bits.GetInt32(ref script) - 1;
                        }
                        if (channel < 0 || channel > sourceChannels.Length - 1)
                            break;
                        if (channels[channel] == null)
                            channels[channel] = new List<Command>();
                        percussiveMode = false;
                        continue;
                    }
                    if (Regex.IsMatch(script[0].ToString(), "[a-g]") || script.StartsWith("r") || script.StartsWith("^"))
                    {
                        Beat beat = Beat.Empty;
                        int ticks = -1;
                        bool Cb = false;
                        Pitch pitch = Pitch.A;
                        if (script.StartsWith("f8cd8}"))
                            script = script.Remove(0, 0);
                        if (Regex.IsMatch(script[0].ToString(), "[a-g]"))
                        {
                            Cb = script.StartsWith("c-");
                            if (script.StartsWith("a-")) { pitch = Pitch.Gs; script = script.Remove(0, 2); }
                            else if (script.StartsWith("a+") || script.StartsWith("b-")) { pitch = Pitch.As; script = script.Remove(0, 2); }
                            else if (script.StartsWith("a")) { pitch = Pitch.A; script = script.Remove(0, 1); }
                            else if (script.StartsWith("b") || script.StartsWith("c-")) { pitch = Pitch.B; script = script.Remove(0, 1); }
                            else if (script.StartsWith("c+") || script.StartsWith("d-")) { pitch = Pitch.Cs; script = script.Remove(0, 2); }
                            else if (script.StartsWith("c")) { pitch = Pitch.C; script = script.Remove(0, 1); }
                            else if (script.StartsWith("d+") || script.StartsWith("e-")) { pitch = Pitch.Ds; script = script.Remove(0, 2); }
                            else if (script.StartsWith("d")) { pitch = Pitch.D; script = script.Remove(0, 1); }
                            else if (script.StartsWith("e") || script.StartsWith("f-")) { pitch = Pitch.E; script = script.Remove(0, 1); }
                            else if (script.StartsWith("f+") || script.StartsWith("g-")) { pitch = Pitch.Fs; script = script.Remove(0, 2); }
                            else if (script.StartsWith("f")) { pitch = Pitch.F; script = script.Remove(0, 1); }
                            else if (script.StartsWith("g+")) { pitch = Pitch.Gs; script = script.Remove(0, 2); }
                            else if (script.StartsWith("g")) { pitch = Pitch.G; script = script.Remove(0, 1); }
                            if (percussiveMode)
                                pitch = percussivePitch;
                        }
                        else if (script.StartsWith("r")) // Stop
                        {
                            pitch = Pitch.Rest;
                            script = script.Remove(0, 1);
                        }
                        else if (script.StartsWith("^")) // Tie
                        {
                            pitch = Pitch.Tie;
                            script = script.Remove(0, 1);
                        }
                        // only if not followed by number
                        if (script.StartsWith("="))
                        {
                            script = script.Remove(0, 1);
                            ticks = Bits.GetInt32(ref script);
                            if (ticks == 144) beat = Beat.HalfDotted;
                            if (ticks == 72) beat = Beat.QuarterDotted;
                            if (ticks == 36) beat = Beat.EighthDotted;
                        }
                        else if (Regex.IsMatch(script[0].ToString(), "[0-9]"))
                            ticks = 192 / Bits.GetInt32(ref script);
                        else if (!Regex.IsMatch(script[0].ToString(), "[0-9]") && setTicks != -1)
                            ticks = setTicks;
                        if (triplet && ticks == 3) ticks = 2;
                        else if (triplet && ticks == 6) ticks = 4;
                        else if (triplet && ticks == 12) beat = Beat.SixteenthTriplet;
                        else if (triplet && ticks == 24) beat = Beat.EighthTriplet;
                        else if (triplet && ticks == 48) beat = Beat.QuarterTriplet;
                        else if (triplet && ticks == 96) ticks = 64;
                        else if (ticks == 3) beat = Beat.SixtyFourth;
                        else if (ticks == 6) beat = Beat.ThirtySecond;
                        else if (ticks == 8) beat = Beat.SixteenthTriplet;
                        else if (ticks == 12) beat = Beat.Sixteenth;
                        else if (ticks == 16) beat = Beat.EighthTriplet;
                        else if (ticks == 24) beat = Beat.Eighth;
                        else if (ticks == 32) beat = Beat.QuarterTriplet;
                        else if (ticks == 36) beat = Beat.EighthDotted;
                        else if (ticks == 48) beat = Beat.Quarter;
                        else if (ticks == 72) beat = Beat.QuarterDotted;
                        else if (ticks == 96) beat = Beat.Half;
                        else if (ticks == 144) beat = Beat.HalfDotted;
                        else if (ticks == 192) beat = Beat.Whole;
                        if (beat != Beat.Empty)
                            opcode = (int)beat * 14 + (int)pitch;
                        else if (ticks != -1)
                        {
                            opcode = 0xB6 + (int)pitch;
                            parameter1 = ticks;
                        }
                        else if (setTicks != -1)
                        {
                            opcode = 0xB6 + (int)pitch;
                            parameter1 = setTicks;
                        }
                        else
                        {
                            opcode = 0xB6 + (int)pitch;
                            parameter1 = 0;
                        }
                        if (Cb)
                            channels[channel].Add(new Command(new byte[] { 0xC5 }, SPC, channel));
                        // to use with . command
                        lastPitch = pitch;
                        lastTicks = ticks;
                    }
                    #endregion
                    #region MML Commands
                    // stop reading line if comment
                    else if (script.StartsWith(";")) { script = script.Remove(0, 1); continue; }
                    else if (script.StartsWith("{")) { triplet = true; script = script.Remove(0, 1); continue; }
                    else if (script.StartsWith("}")) { triplet = false; script = script.Remove(0, 1); continue; }
                    else if (script.StartsWith("/")) { script = script.Remove(0, 1); opcode = 0xD7; }
                    else if (script.StartsWith("<")) { script = script.Remove(0, 1); opcode = 0xC5; octave--; }
                    else if (script.StartsWith(">")) { script = script.Remove(0, 1); opcode = 0xC4; octave++; }
                    else if (script.StartsWith("?")) { script = script.Remove(0, 1); opcode = 0xD0; }
                    else if (script.StartsWith("w"))
                    {
                        script = script.Remove(0, 1);
                        parameter1 = Bits.GetInt32(ref script);
                        if (globalVol == -1)
                            globalVol = parameter1 / 2;
                        continue; // no support for global volume here
                    }
                    else if (script.StartsWith("v"))
                    {
                        script = script.Remove(0, 1);
                        opcode = 0xE2; parameter1 = Bits.GetInt32(ref script) / 2;
                    }
                    else if (script.StartsWith("o"))
                    {
                        script = script.Remove(0, 1);
                        opcode = 0xC6; parameter1 = octave = Bits.GetInt32(ref script);
                    }
                    else if (script.StartsWith("t"))
                    {
                        script = script.Remove(0, 1);
                        opcode = 0xD1;
                        parameter1 = Bits.GetInt32(ref script);
                        parameter1 = (int)(10000.0 / ((double)parameter1 * 1.2 * 2));
                    }
                    else if (script.StartsWith("y"))
                    {
                        script = script.Remove(0, 1);
                        opcode = 0xE7; parameter1 = (Bits.GetInt32(ref script) - 5) * 25;
                    }
                    else if (script.StartsWith("&"))
                    {
                        script = script.Remove(0, 1);
                        opcode = 0xE5; parameter1 = 10; parameter2 = 10;
                    }
                    else if (script.StartsWith("p"))
                    {
                        script = script.Remove(0, 1);
                        opcode = 0xF1;
                        parameter2 = Bits.GetInt32(ref script);
                        script = script.Remove(0, 1); // remove ","
                        parameter1 = Bits.GetInt32(ref script);
                    }
                    else if (script.StartsWith("@") || script.StartsWith("$DA"))
                    {
                        opcode = 0xDE;
                        if (script.StartsWith("@"))
                        {
                            script = script.Remove(0, 1);
                            parameter1 = Bits.GetInt32(ref script);
                        }
                        else
                        {
                            script = script.Remove(0, 3);
                            parameter1 = Bits.GetByte(ref script);
                        }
                        if (!foundInstruments.Contains(parameter1))
                        {
                            foundInstruments.Add(parameter1);
                            newInstruments.Add(parameter1);
                        }
                        // if instrument is a percussive
                        if (nativeFormat != NativeSPC.Custom)
                        {
                            switch (nativeFormat)
                            {
                                case NativeSPC.SMRPG:
                                    if (!Lists.SMRPGPercussives[parameter1]) break;
                                    if (!foundPercussives.Contains(parameter1))
                                    {
                                        foundPercussives.Add(parameter1);
                                        Percussive pr = new Percussive((byte)pitchIndex++, (byte)parameter1, 64, 100, 127);
                                        percussivePitch = pr.PitchIndex;
                                        percussives.Add(pr);
                                    }
                                    else
                                    {
                                        Percussive pr = percussives.Find(delegate(Percussive p) { return p.Sample == parameter1; });
                                        percussivePitch = pr.PitchIndex;
                                    }
                                    goto default;
                                case NativeSPC.SMWOverworld:
                                case NativeSPC.SMWLevel:
                                    if (Lists.SMWPercussives[parameter1] == -1) break;
                                    percussivePitch = (Pitch)Lists.SMWPercussives[parameter1];
                                    goto default;
                                default:
                                    // if not in percussive mode, add command to switch it on
                                    if (!percussiveMode) channels[channel].Add(new Command(new byte[] { 0xEE }, SPC, channel));
                                    percussiveMode = true;
                                    continue;
                            }
                        }
                        // if in percussive mode, add command to switch it off
                        if (percussiveMode) channels[channel].Add(new Command(new byte[] { 0xEF }, SPC, channel));
                        percussiveMode = false;
                    }
                    else if (script.StartsWith("l"))
                    {
                        script = script.Remove(0, 1);
                        setTicks = 192 / Bits.GetInt32(ref script);
                        continue;
                    }
                    else if (script.StartsWith("*"))
                    {
                        script = script.Remove(0, 1);
                        int count = 1;
                        if (Regex.IsMatch(script[0].ToString(), "[0-9]"))
                            count = Bits.GetInt32(ref script);
                        if (!writingLoop && lastLoop != null && channel != -1)
                        {
                            // if starts with a looping command, remove it
                            if (lastLoop[0].Opcode == 0xD4)
                                lastLoop.RemoveAt(0);
                            while (count-- > 0)
                                foreach (var ssc in lastLoop)
                                    channels[channel].Add(ssc);
                        }
                        continue; // labels won't be inserted as commands
                    }
                    else if (script.StartsWith("["))
                    {
                        script = script.Remove(0, 1);
                        if (!writingLoop)
                        {
                            writingLoop = true;
                            lastLoop = new List<Command>();
                        }
                        // go to end of loop to get count
                        // first get number of nested loops
                        int i = 0;
                        int nestedLoopCount = 0;
                        while (script[i] != ']')
                            if (script[i++] == '[')
                                nestedLoopCount++;
                        // second get loop count
                        i = 0;
                        while (nestedLoopCount >= 0)
                            if (script[i++] == ']')
                                nestedLoopCount--;
                        // only if there's an actual loop, otherwise just a non-looping set
                        currentNestedLoop++;
                        if (i < script.Length && Regex.IsMatch(script[i].ToString(), "[0-9]"))
                        {
                            opcode = 0xD4;
                            parameter1 = Bits.GetInt32(ref script, i);
                        }
                        // otherwise skip, no looping to be done, no commands added
                        else
                            continue;
                    }
                    else if (script.StartsWith("]"))
                    {
                        script = script.Remove(0, 1);
                        currentNestedLoop--;
                        if (currentNestedLoop == -1)
                        {
                            writingLabel = false;
                            writingLoop = false;
                        }
                        // only if actually looping
                        if (script != "" && Regex.IsMatch(script[0].ToString(), "[0-9]"))
                        {
                            opcode = 0xD5;
                            script = script.Remove(0, 1); // remove the count
                        }
                        // otherwise if at end of OUTER-MOST non-nested loop
                        else if (currentNestedLoop == -1)
                            continue;
                    }
                    else if (script.StartsWith("("))
                    {
                        int labelLoop = 1;
                        script = script.Remove(0, 1);
                        label = Bits.GetInt32(ref script);
                        script = script.Remove(0, 1); // remove ")"
                        // if next command starts a loop, we're writing a new label
                        if (script.StartsWith("["))
                            writingLabel = true;
                        // otherwise if number follows set loop count
                        else if (Regex.IsMatch(script[0].ToString(), "[0-9]"))
                            labelLoop = Bits.GetInt32(ref script);
                        // if make new label from the following loop []
                        if (writingLabel)
                            labels[label] = new List<Command>();
                        // else if reading an already created label, and label exists, and channel set
                        else if (!writingLabel && labels[label] != null && channel != -1)
                        {
                            var thisLabel = labels[label];
                            // if label starts with a looping command, remove it
                            if (thisLabel[0].Opcode == 0xD4)
                                thisLabel.RemoveAt(0);
                            while (labelLoop-- > 0)
                                foreach (var ssc in thisLabel)
                                    channels[channel].Add(ssc);
                        }
                        continue; // labels won't be inserted as commands
                    }
                    else if (script.StartsWith("."))
                    {
                        script = script.Remove(0, 1);
                        if (lastTicks == 192) { opcode = 2 * 14 + 13; }
                        else if (lastTicks == 144) { opcode = 3 * 14 + 13; }
                        else if (lastTicks == 96) { opcode = 4 * 14 + 13; }
                        else if (lastTicks == 72) { opcode = 5 * 14 + 13; }
                        else if (lastTicks == 64) { opcode = 6 * 14 + 13; }
                        else if (lastTicks == 48) { opcode = 7 * 14 + 13; }
                        else if (lastTicks == 32) { opcode = 8 * 14 + 13; }
                        else if (lastTicks == 24) { opcode = 9 * 14 + 13; }
                        else if (lastTicks == 16) { opcode = 10 * 14 + 13; }
                        else if (lastTicks == 12) { opcode = 11 * 14 + 13; }
                        else if (lastTicks == 6) { opcode = 12 * 14 + 13; }
                        else { opcode = 0xB6 + 13; parameter1 = lastTicks / 2; }
                        lastTicks /= 2;
                    }
                    // q and the hex byte following it
                    else if (script.StartsWith("q")) { script = script.Remove(0, 3); continue; }
                    #endregion
                    #region N-SPC Commands
                    else if (script.StartsWith("$DB")) // speaker balance
                    {
                        script = script.Remove(0, 3);
                        opcode = 0xE7;
                        parameter1 = Bits.GetByte(ref script) * 13;
                    }
                    else if (script.StartsWith("$DC")) // pansweep
                    {
                        script = script.Remove(0, 3);
                        opcode = 0xE8;
                        parameter1 = Bits.GetByte(ref script);
                        parameter2 = Bits.GetByte(ref script) * 13;
                    }
                    else if (script.StartsWith("$DD")) // pitch bend/portamento
                    {
                        script = script.Remove(0, 3);
                        opcode = 0xE5;
                        Bits.GetByte(ref script); // skip first value, SMRPG doesn't support
                        parameter1 = Bits.GetByte(ref script);
                        parameter2 = Bits.GetByte(ref script) - 0x80 + 12;
                        parameter2 = parameter2 - (octave * 12 + (int)lastPitch);
                    }
                    else if (script.StartsWith("$DE")) // vibrato
                    {
                        script = script.Remove(0, 3);
                        opcode = 0xF1;
                        parameter3 = Bits.GetByte(ref script); // delay
                        parameter2 = Bits.GetByte(ref script) / 4; // wavelength
                        parameter1 = Bits.GetByte(ref script) / 2; // amplitude
                    }
                    else if (script.StartsWith("$DF")) // vibrato off
                    {
                        script = script.Remove(0, 3);
                        opcode = 0xF3;
                    }
                    else if (script.StartsWith("$E0")) // global volume, not supported
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        continue;
                    }
                    else if (script.StartsWith("$E1")) // global volume change, not supported
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        parameter2 = Bits.GetByte(ref script); // final balance, not supported
                        continue;
                    }
                    else if (script.StartsWith("$E2")) // tempo
                    {
                        script = script.Remove(0, 3);
                        opcode = 0xD1;
                        parameter1 = Bits.GetByte(ref script);
                        parameter1 = (int)(10000.0 / ((double)parameter1 * 1.2 * 2));
                    }
                    else if (script.StartsWith("$E3")) // tempo change
                    {
                        script = script.Remove(0, 3);
                        opcode = 0xD1;
                        parameter1 = Bits.GetByte(ref script); // speed, not supported
                        parameter2 = Bits.GetByte(ref script);
                        parameter2 = (int)(10000.0 / ((double)parameter2 * 1.2 * 2));
                    }
                    else if (script.StartsWith("$E4")) // global tuning, not supported
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        continue;
                    }
                    else if (script.StartsWith("$E5")) // tremolo or sample switch
                    {
                        script = script.Remove(0, 3);
                        int param1 = Bits.GetByte(ref script);
                        if (param1 < 0x80)
                        {
                            opcode = 0xF0;
                            parameter3 = param1; // delay, not supported
                            parameter2 = Bits.GetByte(ref script); // wavelength
                            parameter1 = Bits.GetByte(ref script); // amplitude
                        }
                        else
                        {
                            opcode = 0xDE;
                            parameter1 = param1 & 0x7F; // sample
                            parameter2 = Bits.GetByte(ref script);
                        }
                    }
                    else if (script.StartsWith("$E6")) // tremolo off
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        if (parameter1 < 0xDA) // loop start
                            opcode = 0xD4;
                        else
                            opcode = 0xF3;
                    }
                    else if (script.StartsWith("$E7")) // channel volume
                    {
                        script = script.Remove(0, 3);
                        opcode = 0xE3;
                        parameter1 = Bits.GetByte(ref script);
                    }
                    else if (script.StartsWith("$E8")) // channel volume shift
                    {
                        script = script.Remove(0, 3);
                        opcode = 0xE4;
                        parameter1 = Bits.GetByte(ref script);
                        parameter2 = Bits.GetByte(ref script);
                    }
                    else if (script.StartsWith("$E9")) // embedded loop, not supported
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        parameter2 = Bits.GetByte(ref script);
                        parameter3 = Bits.GetByte(ref script);
                        continue;
                    }
                    else if (script.StartsWith("$EA")) // vibrato fade, not supported
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        continue;
                    }
                    else if (script.StartsWith("$EB")) // pitch bend to
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        parameter2 = Bits.GetByte(ref script);
                        parameter3 = Bits.GetByte(ref script);
                        continue;
                    }
                    else if (script.StartsWith("$EC")) // pitch bend from
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        parameter2 = Bits.GetByte(ref script);
                        parameter3 = Bits.GetByte(ref script);
                        continue;
                    }
                    else if (script.StartsWith("$ED")) // ADSR
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        if (parameter1 == 0x80)
                        {
                            parameter2 = Bits.GetByte(ref script);
                            parameter3 = Bits.GetByte(ref script);
                            continue; // not supported
                        }
                        else if (parameter1 == 0x81)
                        {
                            opcode = 0xED;
                            parameter2 = (sbyte)Bits.GetByte(ref script) * 4;
                        }
                        else if (parameter1 == 0x82)
                        {
                            int param1 = Bits.GetShort(ref script);
                            int param2 = Bits.GetShort(ref script);
                            while (param2-- >= 0)
                                Bits.GetByte(ref script);
                            continue; // not supported
                        }
                        else if (parameter1 == 0x83)
                        {
                            int param1 = Bits.GetShort(ref script);
                            int param2 = Bits.GetShort(ref script);
                            while (param2-- > 0)
                                Bits.GetByte(ref script);
                            continue; // not supported
                        }
                        else
                        {
                            parameter2 = Bits.GetByte(ref script);
                            //channels[channel].Add(new SPCScriptCommand(new byte[] { 0xD9, (byte)(parameter2 & 0x0F) }, spc, channel));
                            //channels[channel].Add(new SPCScriptCommand(new byte[] { 0xDA, (byte)(parameter2 >> 5) }, spc, channel));
                            //channels[channel].Add(new SPCScriptCommand(new byte[] { 0xDB, (byte)(parameter2 >> 5) }, spc, channel));
                            //channels[channel].Add(new SPCScriptCommand(new byte[] { 0xDC, (byte)(parameter2 & 0x1F) }, spc, channel));
                            continue;
                        }
                    }
                    else if (script.StartsWith("$EE")) // channel tuning
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        continue;
                    }
                    else if (script.StartsWith("$EF")) // echo
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        parameter2 = Bits.GetByte(ref script);
                        parameter3 = Bits.GetByte(ref script);
                        continue;
                    }
                    else if (script.StartsWith("$F0")) // reverb off
                    {
                        script = script.Remove(0, 3);
                        opcode = 0xFB;
                    }
                    else if (script.StartsWith("$F1")) // echo
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        parameter2 = Bits.GetByte(ref script);
                        parameter3 = Bits.GetByte(ref script);
                        continue;
                    }
                    else if (script.StartsWith("$F2")) // secondary echo
                    {
                        script = script.Remove(0, 3);
                        parameter1 = Bits.GetByte(ref script);
                        parameter2 = Bits.GetByte(ref script);
                        parameter3 = Bits.GetByte(ref script);
                        continue;
                    }
                    #endregion
                    // if non-MML command, ignore and skip
                    else if (script.StartsWith("$")) { script = script.Remove(0, 3); continue; }
                    // no legitimate commands, so skip and continue
                    else { script = script.Remove(0, 1); continue; }
                    // create the command data
                    if (channel != -1)
                    {
                        length = ScriptEnums.CommandLengths[opcode];
                        command = new byte[length];
                        if (length > 0) command[0] = (byte)opcode;
                        if (length > 1) command[1] = (byte)parameter1;
                        if (length > 2) command[2] = (byte)parameter2;
                        if (length > 3) command[3] = (byte)parameter3;
                        Command ssc;
                        if (Type == ElementType.SPCTrack)
                            ssc = new Command(command, (SPCTrack)this.SPC, channel);
                        else
                            ssc = new Command(command, (SPCSound)this.SPC, channel);
                        channels[channel].Add(ssc);
                        // if writing a label, add the command to the current label too
                        if (writingLabel) labels[label].Add(ssc.Copy());
                        if (writingLoop) lastLoop.Add(ssc.Copy());
                    }
                }
                catch (Exception ex)
                {
                    error += "Error reading line #" + lineNumber + " (\"" + script + "\"). " + ex.Message + "\n";
                }
                lineNumber++;
            }
            if (error == "")
                MessageBox.Show("Import successful.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                new NewMessageBox("LAZY SHELL", "There were some errors importing the channel script.", error, "", MessageIcon.Warning).ShowDialog();
            //
            #region Finalize
            this.Updating = true;
            for (int i = 0; i < sourceChannels.Length; i++)
            {
                sourceChannels[i] = channels[i];
                activeChannels[i] = channels[i] != null;
                if (sourceChannels[i] == null)
                    sourceChannels[i] = new List<Command>();
                this.activeChannels[i].Checked = activeChannels[i];
                // terminate channel with 0xD0 if not already terminated
                if (activeChannels[i] && sourceChannels.Length > 0)
                    switch (sourceChannels[i][sourceChannels[i].Count - 1].Opcode)
                    {
                        case 0xCD:
                        case 0xCE:
                        case 0xD0:
                            break;
                        default:
                            sourceChannels[i].Add(new Command(new byte[] { 0xD0 }, SPC, i));
                            break;
                    }
            }
            // replace samples with native ones
            foundInstruments.Sort();
            newInstruments.Sort();
            switch (nativeFormat)
            {
                case NativeSPC.Custom:
                    PickInstruments pickInstruments = new PickInstruments(foundInstruments, newInstruments);
                    pickInstruments.ShowDialog();
                    break;
                case NativeSPC.SMWOverworld:
                case NativeSPC.SMWLevel:
                    for (int i = 0; i < newInstruments.Count; i++)
                        newInstruments[i] = Lists.SMWSamples[foundInstruments[i]];
                    break;
            }
            for (int a = 0; a < sourceChannels.Length; a++)
            {
                if (sourceChannels[a] == null) continue;
                foreach (var ssc in sourceChannels[a])
                {
                    if (ssc.Opcode == 0xDE)
                        for (int i = 0; i < foundInstruments.Count; i++)
                            if (ssc.Param1 == foundInstruments[i])
                            {
                                ssc.Param1 = (byte)newInstruments[i];
                                break;
                            }
                }
            }
            InstrumentsForm.LoadNewInstruments(newInstruments, globalVol);
            // set percussives
            SPC.Percussives = percussives;
            //
            this.Updating = false;
            #endregion
            return true;
        }
        public void ExportMMLScript(ExportMode exportMode)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = LazyShell.Model.GetFileNameWithoutPath() + " - ";
            if (exportMode == 0)
                saveFileDialog.FileName += "SPCMML-" + Index.ToString("d2");
            else
                saveFileDialog.FileName += "StaffsMML";
            saveFileDialog.FileName += ".txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            //
            var pickNativeSPC = new PickNativeSPC();
            if (pickNativeSPC.ShowDialog() == DialogResult.Cancel)
                return;
            var nativeFormat = (NativeSPC)pickNativeSPC.Tag;
            //
            var writer = File.CreateText(saveFileDialog.FileName);
            string script;
            if (exportMode == 0)
                script = ";SMRPG track {" + Index + "}  " + Lists.SPCTracks[Index] + "\n\n";
            else
                script = ";LAZY SHELL SCORE\n\n";
            if (nativeFormat == NativeSPC.SMWLevel)
                script += "$ED $80 $6D $2B\n" + "$ED $80 $7D $00\n" + "$F0\n\n";
            if (nativeFormat == NativeSPC.SMWOverworld)
                script += "$ED $80 $6D $68\n" + "$ED $80 $7D $00\n" + "$F0\n\n";
            //
            List<Command>[] channels;
            if (exportMode == 0)
            {
                if (MessageBox.Show("Would you like to include nested loops? Selecting \"No\" will save the file to a loopless, uncompressed format.",
                    "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    channels = (SPC as SPCTrack).CompatibilizeMML(nativeFormat);
                else
                    channels = SPC.Channels;
            }
            else
                channels = Music.StaffsToChannels(staffs, SPC);
            var labels = new List<Command>[256];
            for (int c = 0; c < channels.Length; c++)
            {
                if (channels == null) break;
                if (channels[c] == null || (exportMode == ExportMode.ExportSPC && !SPC.ActiveChannels[c]))
                    continue;
                int sample = 0;
                bool percussionMode = false;
                script += "\n\n#" + c + "\n\n";
                if (c == 0) script += "w180 ";
                for (int i = 0; i < channels[c].Count; i++)
                {
                    //if (i != 0 && i % 20 == 0) 
                    //    script += "\n";
                    Command ssc = channels[c][i];
                    switch (ssc.Opcode)
                    {
                        case 0xC4: script += ">"; break;
                        case 0xC5: script += "<"; break;
                        case 0xC6: script += " o" + (ssc.Param1 - 0) + " "; break;
                        case 0xD0: break;// if (c == channels.Length - 1) script += "\n?\n"; break;
                        case 0xD1:
                            int tempo = (int)(10000.0 / (double)ssc.Param1 / 2.0 / 1.2);
                            script += " t" + tempo + " "; break;
                        case 0xD4:
                            script += "["; i++;
                            ExportMMLLoop(ref channels, ref script, c, ref i, ssc.Param1, ref percussionMode, ref sample, nativeFormat);
                            script += "\n";
                            break;
                        case 0xD5: break;
                        case 0xD6: break;
                        case 0xD7: script += "\n/\n"; break;
                        case 0xDE:
                            sample = ssc.Param1;
                            switch (nativeFormat)
                            {
                                case NativeSPC.SMWOverworld:
                                case NativeSPC.SMWLevel: script += " @" + Lists.SMRPGtoSMWSamples[ssc.Param1] + " "; break;
                                default: script += "\n$DA $" + ssc.Param1.ToString("X2") + " "; break;
                            }
                            break;
                        case 0xE2: script += " v" + (ssc.Param1 * 2) + " "; break;
                        //case 0xE5: script += "&"; break;
                        case 0xE7: script += " y" + (ssc.Param1 / 25 + 5) + " "; break;
                        case 0xEE: percussionMode = true; break;
                        case 0xEF: percussionMode = false; break;
                        case 0xF1: script += " p" + ssc.Param2 + "," + ssc.Param1 + " "; break;
                        default:
                            if (ssc.Opcode < 0xC4)
                            {
                                Note note = new Note(ssc, 5, percussionMode, sample);
                                // create instrument change for percussives
                                if (percussionMode)
                                {
                                    Percussive percussive = SPC.Percussives.Find(
                                        delegate(Percussive p) { return p.PitchIndex == note.Pitch; });
                                    if (percussive != null && sample != percussive.Sample)
                                    {
                                        switch (nativeFormat)
                                        {
                                            case NativeSPC.SMWOverworld:
                                            case NativeSPC.SMWLevel: script += " @" + Lists.SMRPGtoSMWSamples[percussive.Sample] + " "; break;
                                            default: script += "\n$DA $" + percussive.Sample.ToString("X2") + " "; break;
                                        }
                                    }
                                }
                                switch (note.Pitch)
                                {
                                    case Pitch.A: script += "a"; break;
                                    case Pitch.As: script += "a+"; break;
                                    case Pitch.B: script += "b"; break;
                                    case Pitch.C: script += "c"; break;
                                    case Pitch.Cs: script += "c+"; break;
                                    case Pitch.D: script += "d"; break;
                                    case Pitch.Ds: script += "d+"; break;
                                    case Pitch.E: script += "e"; break;
                                    case Pitch.F: script += "f"; break;
                                    case Pitch.Fs: script += "f+"; break;
                                    case Pitch.G: script += "g"; break;
                                    case Pitch.Gs: script += "g+"; break;
                                    case Pitch.Rest: script += "r"; break;
                                    case Pitch.Tie: script += "^"; break;
                                    default: script += "r"; break;
                                }
                                if (ssc.Opcode < 0xB6)
                                    switch (note.Beat)
                                    {
                                        case Beat.Whole: script += "1"; break;
                                        case Beat.HalfDotted: script += "2."; break; // dotted half
                                        case Beat.Half: script += "2"; break;
                                        case Beat.QuarterDotted: script += "4."; break; // dotted quarter
                                        case Beat.Quarter: script += "4"; break;
                                        case Beat.EighthDotted: script += "8."; break; // dotted 8th
                                        case Beat.QuarterTriplet: script += "6"; break; // quarter triplet
                                        case Beat.Eighth: script += "8"; break;
                                        case Beat.EighthTriplet: script += "12"; break; // 8th triplet
                                        case Beat.Sixteenth: script += "16"; break;
                                        case Beat.SixteenthTriplet: script += "24"; break; // 16th triplet
                                        case Beat.ThirtySecond: script += "32"; break;
                                        case Beat.SixtyFourth: script += "64"; break;
                                        default: break;
                                    }
                                else
                                    script += "=" + ssc.Param1;
                            }
                            break;
                    }
                }
            }
            script = Regex.Replace(script, " {2,}", " ");
            script = Regex.Replace(script, "\\[ ", "[");
            script = Regex.Replace(script, " \\]", "]");
            script = Regex.Replace(script, "\\[\n", "[");
            script = Regex.Replace(script, "\n +", "\n");
            script = Regex.Replace(script, "\n{3,}", "\n\n");
            script = Regex.Replace(script, "\n", "\r\n");
            writer.Write(script);
            writer.Close();
        }
        private void ExportMMLLoop(ref List<Command>[] channels, ref string script, int c, ref int i,
            int loopCount, ref bool percussionMode, ref int sample, NativeSPC nativeFormat)
        {
            int loopStart = i;
            int firstSectionStart = -1;
            int firstSectionEnd = -1;
            bool writingBeginning = false;
            for (; i < channels[c].Count; i++)
            {
                //if (i != 0 && i % 20 == 0)
                //    script += "\n";
                Command ssc = channels[c][i];
                if (writingBeginning && i == firstSectionStart)
                {
                    i = firstSectionEnd;
                    return;
                }
                switch (ssc.Opcode)
                {
                    case 0xC4: script += ">"; break;
                    case 0xC5: script += "<"; break;
                    case 0xC6: script += " o" + (ssc.Param1 - 0) + " "; break;
                    case 0xD0: break;// if (c == channels.Length - 1) script += "\n?\n"; break;
                    case 0xD4:
                        script += "\n["; i++;
                        ExportMMLLoop(ref channels, ref script, c, ref i, ssc.Param1, ref percussionMode, ref sample, nativeFormat);
                        break;
                    case 0xD5:
                        script += "]" + loopCount;
                        if (firstSectionStart != -1)
                        {
                            firstSectionEnd = i;
                            writingBeginning = true;
                            i = loopStart - 1;
                        }
                        else
                            return;
                        break;
                    case 0xD6:
                        loopCount--;
                        firstSectionStart = i;
                        break;
                    case 0xD7: script += "\n/\n"; break;
                    case 0xDE:
                        sample = ssc.Param1;
                        switch (nativeFormat)
                        {
                            case NativeSPC.SMWOverworld:
                            case NativeSPC.SMWLevel: script += " @" + Lists.SMRPGtoSMWSamples[ssc.Param1] + " "; break;
                            default: script += "\n$DA $" + ssc.Param1.ToString("X2") + " "; break;
                        }
                        break;
                    case 0xE2: script += " v" + (ssc.Param1 * 2) + " "; break;
                    //case 0xE5: script += "&"; break;
                    case 0xE7: script += " y" + (ssc.Param1 / 25 + 5) + " "; break;
                    case 0xEE: percussionMode = true; break;
                    case 0xEF: percussionMode = false; break;
                    case 0xF1: script += " p" + ssc.Param2 + "," + ssc.Param1 + " "; break;
                    default:
                        if (ssc.Opcode < 0xC4)
                        {
                            Note note = new Note(ssc, 5, percussionMode, sample);
                            // create instrument change for percussives
                            if (percussionMode)
                            {
                                Percussive percussive = SPC.Percussives.Find(
                                    delegate(Percussive p) { return p.PitchIndex == note.Pitch; });
                                if (percussive != null && sample != percussive.Sample)
                                {
                                    switch (nativeFormat)
                                    {
                                        case NativeSPC.SMWOverworld:
                                        case NativeSPC.SMWLevel: script += " @" + Lists.SMRPGtoSMWSamples[percussive.Sample] + " "; break;
                                        default: script += "\n$DA $" + percussive.Sample.ToString("X2") + " "; break;
                                    }
                                }
                            }
                            switch (note.Pitch)
                            {
                                case Pitch.A: script += "a"; break;
                                case Pitch.As: script += "a+"; break;
                                case Pitch.B: script += "b"; break;
                                case Pitch.C: script += "c"; break;
                                case Pitch.Cs: script += "c+"; break;
                                case Pitch.D: script += "d"; break;
                                case Pitch.Ds: script += "d+"; break;
                                case Pitch.E: script += "e"; break;
                                case Pitch.F: script += "f"; break;
                                case Pitch.Fs: script += "f+"; break;
                                case Pitch.G: script += "g"; break;
                                case Pitch.Gs: script += "g+"; break;
                                case Pitch.Rest: script += "r"; break;
                                case Pitch.Tie: script += "^"; break;
                                default: script += "r"; break;
                            }
                            if (ssc.Opcode < 0xB6)
                                switch (note.Beat)
                                {
                                    case Beat.Whole: script += "1"; break;
                                    case Beat.HalfDotted: script += "2^4"; break; // dotted half
                                    case Beat.Half: script += "2"; break;
                                    case Beat.QuarterDotted: script += "4^8"; break; // dotted quarter
                                    case Beat.Quarter: script += "4"; break;
                                    case Beat.EighthDotted: script += "8^16"; break; // dotted 8th
                                    case Beat.QuarterTriplet: script += "6"; break; // quarter triplet
                                    case Beat.Eighth: script += "8"; break;
                                    case Beat.EighthTriplet: script += "12"; break; // 8th triplet
                                    case Beat.Sixteenth: script += "16"; break;
                                    case Beat.SixteenthTriplet: script += "24"; break; // 16th triplet
                                    case Beat.ThirtySecond: script += "32"; break;
                                    case Beat.SixtyFourth: script += "64"; break;
                                    default: break;
                                }
                            else
                                script += "=" + ssc.Param1;
                        }
                        break;
                }
            }
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            samplesForm.SoundPlayer.Stop();
            if (!this.Modified && !samplesForm.Modified)
                return;
            samplesForm.SoundPlayer.Stop();
            //
            var result = MessageBox.Show(
              "Audio has not been saved.\n\nWould you like to save changes?",
              "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                save.PerformClick();
            else if (result == DialogResult.No)
                Model.ClearAll();
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        // Navigators
        private void soundType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load properties
            if (!this.Updating)
            {
                SetListControls();
                SaveLastLoadedIndex();
                LoadProperties();
                SetFreeBytesLabel();
            }
        }
        private void trackNum_ValueChanged(object sender, EventArgs e)
        {
            trackName.SelectedIndex = (int)trackNum.Value;
            if (!this.Updating)
            {
                SaveLastLoadedIndex();
                LoadProperties();
            }
        }
        private void trackName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Type == ElementType.SPCTrack && trackName.SelectedIndex == 0)
                trackName.SelectedIndex = 1;
            trackNum.Value = trackName.SelectedIndex;
        }
        private void findReferences_Click(object sender, EventArgs e)
        {
            if (findReferencesForm == null)
            {
                findReferencesForm = new FindReferences(new FindReferencesFunction(FindReferences), null);
                findReferencesForm.Owner = this;
            }
            else
                findReferencesForm.Reload();
            findReferencesForm.Show();
        }

        // Toolstrip
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM(true);
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the current SPC? You will lose all unsaved changes.",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            if (Type == ElementType.SPCTrack)
                Model.SPCs[Index] = new SPCTrack(Index);
            else if (Type == ElementType.SPCEvent)
                Model.SPCEvent[Index] = new SPCSound(Index, ElementType.SPCEvent);
            else
                Model.SPCBattle[Index] = new SPCSound(Index, ElementType.SPCBattle);
            //
            LoadProperties();
        }
        private void importMML_Click(object sender, EventArgs e)
        {
            if (!ImportMMLScript(SPC.Channels, SPC.ActiveChannels))
                return;
            if (Type == ElementType.SPCTrack)
                (SPC as SPCTrack).WriteToBuffer();
            //
            SPC.CreateNotes();
            LoadProperties();
        }
        private void exportMML_Click(object sender, EventArgs e)
        {
            ExportMMLScript(ExportMode.ExportSPC);
        }
        private void importTrack_Click(object sender, EventArgs e)
        {
            if (Type == ElementType.SPCTrack)
                new IOElements(Model.SPCs, IOMode.Import, Index, "IMPORT SPCs...").ShowDialog();
            else if (Type == ElementType.SPCEvent)
                new IOElements(Model.SPCEvent, IOMode.Import, Index, "IMPORT EVENT SOUNDS...").ShowDialog();
            else
                new IOElements(Model.SPCBattle, IOMode.Import, Index, "IMPORT BATTLE SOUNDS...").ShowDialog();
            LoadProperties();
        }
        private void exportTrack_Click(object sender, EventArgs e)
        {
            if (Type == ElementType.SPCTrack)
                new IOElements(Model.SPCs, IOMode.Export, Index, "EXPORT SPCs...").ShowDialog();
            else if (Type == ElementType.SPCEvent)
                new IOElements(Model.SPCEvent, IOMode.Export, Index, "EXPORT EVENT SOUNDS...").ShowDialog();
            else
                new IOElements(Model.SPCBattle, IOMode.Export, Index, "EXPORT BATTLE SOUNDS...").ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            ClearElements clearElements;
            if (Type == ElementType.SPCTrack)
                clearElements = new ClearElements(Model.SPCs, Index, "CLEAR SPCS...");
            else if (Type == ElementType.SPCEvent)
                clearElements = new ClearElements(Model.SPCEvent, Index, "CLEAR EVENT SOUNDS...");
            else
                clearElements = new ClearElements(Model.SPCBattle, Index, "CLEAR BATTLE SOUNDS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            if (Type == ElementType.SPCTrack)
                (SPC as SPCTrack).WriteToBuffer();
            LoadProperties();
        }
        private void openHexEditor_Click(object sender, EventArgs e)
        {
            int offset;
            if (Type == ElementType.SPCTrack)
                offset = Bits.GetInt24(Model.ROM, Index * 3 + 0x042748);
            else if (Type == ElementType.SPCEvent)
                offset = Bits.GetShort(Model.ROM, Index * 4 + 0x042826) - 0x3400 + 0x042C26;
            else
                offset = Bits.GetShort(Model.ROM, Index * 4 + 0x043E26) - 0x3400 + 0x044226;
            LazyShell.Model.HexEditor.SetOffset(offset - 0xC00000);
            LazyShell.Model.HexEditor.HighlightChanges();
            LazyShell.Model.HexEditor.Show();
        }
        private void openPreviewer_Click(object sender, EventArgs e)
        {
            if (previewerForm != null && previewerForm.Visible)
                previewerForm.Close();
            if (Type == ElementType.SPCTrack)
                previewerForm = new PreviewerForm(Index, autoLaunch.Checked, ElementType.SPCTrack);
            else if (Type == ElementType.SPCEvent)
                previewerForm = new PreviewerForm(Index, autoLaunch.Checked, ElementType.SPCEvent);
            else if (Type == ElementType.SPCBattle)
                previewerForm = new PreviewerForm(Index, autoLaunch.Checked, ElementType.SPCBattle);
            if (!autoLaunch.Checked)
                previewerForm.Show();
        }

        #endregion
    }
}
