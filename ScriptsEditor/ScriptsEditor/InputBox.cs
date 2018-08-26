using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DialogEditor
{
    public static class InputBox
    {

        // Conserva esta cabecera
        //  Emperorxdevil 2007

        private static Form f;
        private static Label l;
        private static TextBox t; // Elementos necesarios
        private static Button b1;
        private static Button b2;
        private static string valor;

        /// &#60;summary&#62;
        /// Objeto Estático que muestra un pequeño diálogo para introducir datos
        /// &#60;/summary&#62;
        /// &#60;param name="title"&#62;Título del diálogo&#60;/param&#62;
        /// &#60;param name="prompt"&#62;Texto de información&#60;/param&#62;
        /// &#60;param name="posicion"&#62;Posición de inicio&#60;/param&#62;
        /// &#60;returns&#62;Devuelve la escrito en la caja de texto como string&#60;/returns&#62;
        public static string Show(string title, string prompt, FormStartPosition posicion)
        {

            f = new Form
            {
                Text = title,
                ShowIcon = false,
                Icon = null,
                KeyPreview = true,
                ShowInTaskbar = false,
                MaximizeBox = false,
                MinimizeBox = false,
                Width = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Height = 125,
                StartPosition = posicion
            };
            f.KeyPress += FKeyPress;

            l = new Label { AutoSize = true, Text = prompt };


            t = new TextBox { Width = 182, Top = 40 };

            b1 = new Button { Text = "Aceptar" };
            b1.Click += B1Click;


            b2 = new Button { Text = "Cancelar" };
            b2.Click += B2Click;

            f.Controls.Add(l);
            f.Controls.Add(t);
            f.Controls.Add(b1);
            f.Controls.Add(b2);

            l.Top = 10;
            t.Left = 5;
            t.Top = 30;

            b1.Left = 5;
            b1.Top = 60;

            b2.Left = 112;
            b2.Top = 60;

            f.Width = (int)f.CreateGraphics().MeasureString(prompt, l.Font).Width + 4;
            t.Width = l.Width - 4;

            f.ShowDialog();
            return (valor);
        }

        private static void FKeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Return:
                    Acepta();
                    break;
                case (char)Keys.Escape:
                    Cancela();
                    break;
            }
        }

        private static void B2Click(object sender, EventArgs e)
        {
            Cancela();
        }

        private static void B1Click(object sender, EventArgs e)
        {
            Acepta();
        }

        private static string Val
        {
            set { valor = value; }
        }

        private static void Acepta()
        {
            Val = t.Text;
            f.Dispose();
        }

        private static void Cancela()
        {
            Val = null;
            f.Dispose();
        }

    }
}
