namespace SkyUnityLauncher
{
    partial class Launcher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            startServer = new Button();
            SuspendLayout();
            // 
            // startServer
            // 
            startServer.Location = new Point(549, 377);
            startServer.Name = "startServer";
            startServer.Size = new Size(228, 48);
            startServer.TabIndex = 0;
            startServer.Text = "Start Server";
            startServer.UseVisualStyleBackColor = true;
            startServer.Click += startServer_Click;
            // 
            // Launcher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(startServer);
            Name = "Launcher";
            Text = "SkyUnityLauncher";
            ResumeLayout(false);
        }

        #endregion

        private Button startServer;
    }
}