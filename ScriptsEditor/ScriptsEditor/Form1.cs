using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DialogEditor
{
    public partial class Form1 : Form
    {
        private DialogTree CurrentDialog;
        private DialogNode CurrentNode;
        private string CurrentPath;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdLoadScene_Click(object sender, EventArgs e)
        {
            var file = OpenDialog("Seleccione escena", "Archivos Unity | *.unity");

            if (String.IsNullOrEmpty(file))
                return;

            var fileName = Path.GetFileNameWithoutExtension(file);
            var dir = Path.GetDirectoryName(file);

            CurrentPath = Path.Combine(dir, fileName);

            cmbKey.Items.Clear();

            foreach (var f in Directory.GetFiles(CurrentPath))
            {
                var lowerFile = f.ToLowerInvariant();
                if (!lowerFile.EndsWith(DialogTree.DIALOG_EXTENSION))
                    continue;

                cmbKey.Items.Add(Path.GetFileNameWithoutExtension(f));
            }

            lblScene.Text = $"ESCENA '{fileName}'";
        }


        private static string OpenDialog(string tittle, string extension)
        {
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Reset();
                openDialog.Title = tittle;

                openDialog.Filter = extension;
                openDialog.Multiselect = false;

                openDialog.ShowDialog();

                return openDialog.FileName;
            }
        }

        private void cmdNewDialog_Click(object sender, EventArgs e)
        {
            var key = InputBox.Show("Nuevo Diálogo", "Indicar clave para nuevo diálogo", FormStartPosition.CenterScreen);

            var nDialog = new DialogTree
            {
                Root = new DialogNode
                {
                    Owner = "Unknown",
                    Text = "..."
                },
                DialogKey = key
            };
            var file = Path.Combine(CurrentPath, key + DialogTree.DIALOG_EXTENSION);
            SaveDialog(nDialog, file);

            cmbKey.Items.Add(key);
            cmbKey.SelectedIndex = cmbKey.Items.Count - 1;
        }

        private void SaveDialog(DialogTree dialog, string file)
        { 
            var text = dialog.AsString();
            
            using (var writer = new StreamWriter(file))
            {
                writer.WriteLine(text);
                writer.Flush();
                writer.Close();
            }
        }

        private void cmbKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fileName = Path.Combine(CurrentPath, cmbKey.Text + DialogTree.DIALOG_EXTENSION);
            if (!File.Exists(fileName))
                throw new Exception($"Archivo {fileName} no encontrado");

            using (var reader = new StreamReader(fileName))
            {
                var text = reader.ReadToEnd();
                reader.Close();

                CurrentDialog = DialogTree.FromString(text);
            }
            LoadDialog();
        }

        private void LoadDialog()
        {
            txtDialogKey.Text = CurrentDialog.DialogKey;
            SaveNode();
            CurrentNode = CurrentDialog.Root;
            LoadNode();
        }

        private void cmdRoot_Click(object sender, EventArgs e)
        {
            SaveNode();
            CurrentNode = CurrentDialog.Root;
            LoadNode();
        }

        private void LoadNode()
        {
            cmdParent.Enabled = CurrentNode.parent != null;

            txtOwner.Text = CurrentNode.Owner;
            cmbType.SelectedIndex = CurrentNode.DialogType;
            cmbMood.SelectedIndex = CurrentNode.Mood;
            cmbSpeed.SelectedIndex = CurrentNode.Speed;
            txtText.Text = CurrentNode.Text;

            btnCurrent.Text = CurrentNode.DialogId.ToString();

            cmbChildren.Items.Clear();

            foreach (var n in CurrentNode.children)
                cmbChildren.Items.Add(n.DialogId + " -- " + n.Owner);

            lblChildCount.Text = CurrentNode.children.Count.ToString();

            /*
            for (int i = 0; i < CurrentNode.children.Count; i++)
                cmbChildren.Items.Add(i);
            */
            /*
            if (cmbChildren.Items.Count > 0 )
                cmbChildren.SelectedItem = 0;*/
        }

        private void SaveNode()
        {
            if (CurrentNode == null)
                return;

            CurrentNode.Owner = txtOwner.Text;
            CurrentNode.DialogType = cmbType.SelectedIndex;
            CurrentNode.Mood = cmbMood.SelectedIndex;
            CurrentNode.Speed = cmbSpeed.SelectedIndex;
            CurrentNode.Text = txtText.Text;

        }

        private void cmbChildren_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveNode();
            CurrentNode = CurrentNode.children[cmbChildren.SelectedIndex];
            LoadNode();
        }

        private void cmdNewChild_Click(object sender, EventArgs e)
        {
            SaveNode();
            CurrentDialog.KeyCount++;
            var nNode = new DialogNode
            {
                Owner = "",
                Text = "",
                DialogId = CurrentDialog.KeyCount,
                parent = CurrentNode,
                ParentId = CurrentNode.DialogId,
            };
            CurrentNode.children.Add(nNode);
            CurrentNode = nNode;
            LoadNode();
        }

        private void cmdSaveDialog_Click(object sender, EventArgs e)
        {
            var fileName = Path.Combine(CurrentPath, cmbKey.Text + DialogTree.DIALOG_EXTENSION);
            SaveDialog(CurrentDialog, fileName);
            MessageBox.Show("Salvado!");
        }

        private void cmdParent_Click(object sender, EventArgs e)
        {
            SaveNode();
            CurrentNode = CurrentNode.parent;
            LoadNode();
        }
    }
}
