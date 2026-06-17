using System.Reflection.Metadata;

namespace Primer_actividad
{
    partial class FrmJuego
   Private controlador As JuegoController

    Private Sub FrmJuego_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        controlador = New JuegoController(Me)
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click

        controlador.SiguienteNivel()

    End Sub

End Class

        #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1450, 550);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
    }
}
