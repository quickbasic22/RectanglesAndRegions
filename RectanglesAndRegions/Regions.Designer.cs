namespace RectanglesAndRegions
{
    partial class Regions
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
            menuStrip1 = new MenuStrip();
            rectangleToolStripMenuItem = new ToolStripMenuItem();
            roundTruncateAndOtherMethodsToolStripMenuItem = new ToolStripMenuItem();
            containsToolStripMenuItem = new ToolStripMenuItem();
            rectangeFToolStripMenuItem = new ToolStripMenuItem();
            regionToolStripMenuItem = new ToolStripMenuItem();
            constructToolStripMenuItem = new ToolStripMenuItem();
            complementToolStripMenuItem = new ToolStripMenuItem();
            emptyAndOthersToolStripMenuItem = new ToolStripMenuItem();
            excludeToolStripMenuItem = new ToolStripMenuItem();
            unionToolStripMenuItem = new ToolStripMenuItem();
            xorToolStripMenuItem = new ToolStripMenuItem();
            entersectToolStripMenuItem = new ToolStripMenuItem();
            exclToolStripMenuItem = new ToolStripMenuItem();
            clippingToolStripMenuItem = new ToolStripMenuItem();
            excludeClipToolStripMenuItem = new ToolStripMenuItem();
            setClipToolStripMenuItem = new ToolStripMenuItem();
            translateClipToolStripMenuItem = new ToolStripMenuItem();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { rectangleToolStripMenuItem, rectangeFToolStripMenuItem, regionToolStripMenuItem, clippingToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // rectangleToolStripMenuItem
            // 
            rectangleToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { roundTruncateAndOtherMethodsToolStripMenuItem, containsToolStripMenuItem });
            rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            rectangleToolStripMenuItem.Size = new Size(71, 20);
            rectangleToolStripMenuItem.Text = "Rectangle";
            // 
            // roundTruncateAndOtherMethodsToolStripMenuItem
            // 
            roundTruncateAndOtherMethodsToolStripMenuItem.Name = "roundTruncateAndOtherMethodsToolStripMenuItem";
            roundTruncateAndOtherMethodsToolStripMenuItem.Size = new Size(264, 22);
            roundTruncateAndOtherMethodsToolStripMenuItem.Text = "Round, Truncate and other methods";
            roundTruncateAndOtherMethodsToolStripMenuItem.Click += roundTruncateAndOtherMethodsToolStripMenuItem_Click;
            // 
            // containsToolStripMenuItem
            // 
            containsToolStripMenuItem.Name = "containsToolStripMenuItem";
            containsToolStripMenuItem.Size = new Size(264, 22);
            containsToolStripMenuItem.Text = "Contains";
            containsToolStripMenuItem.Click += containsToolStripMenuItem_Click;
            // 
            // rectangeFToolStripMenuItem
            // 
            rectangeFToolStripMenuItem.Name = "rectangeFToolStripMenuItem";
            rectangeFToolStripMenuItem.Size = new Size(74, 20);
            rectangeFToolStripMenuItem.Text = "RectangeF";
            // 
            // regionToolStripMenuItem
            // 
            regionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { constructToolStripMenuItem, complementToolStripMenuItem, emptyAndOthersToolStripMenuItem, excludeToolStripMenuItem, unionToolStripMenuItem, xorToolStripMenuItem, entersectToolStripMenuItem, exclToolStripMenuItem });
            regionToolStripMenuItem.Name = "regionToolStripMenuItem";
            regionToolStripMenuItem.Size = new Size(56, 20);
            regionToolStripMenuItem.Text = "Region";
            // 
            // constructToolStripMenuItem
            // 
            constructToolStripMenuItem.Name = "constructToolStripMenuItem";
            constructToolStripMenuItem.Size = new Size(171, 22);
            constructToolStripMenuItem.Text = "Construct";
            constructToolStripMenuItem.Click += constructToolStripMenuItem_Click;
            // 
            // complementToolStripMenuItem
            // 
            complementToolStripMenuItem.Name = "complementToolStripMenuItem";
            complementToolStripMenuItem.Size = new Size(171, 22);
            complementToolStripMenuItem.Text = "Complement";
            complementToolStripMenuItem.Click += complementToolStripMenuItem_Click;
            // 
            // emptyAndOthersToolStripMenuItem
            // 
            emptyAndOthersToolStripMenuItem.Name = "emptyAndOthersToolStripMenuItem";
            emptyAndOthersToolStripMenuItem.Size = new Size(171, 22);
            emptyAndOthersToolStripMenuItem.Text = "Empty And Others";
            emptyAndOthersToolStripMenuItem.Click += emptyAndOthersToolStripMenuItem_Click;
            // 
            // excludeToolStripMenuItem
            // 
            excludeToolStripMenuItem.Name = "excludeToolStripMenuItem";
            excludeToolStripMenuItem.Size = new Size(171, 22);
            excludeToolStripMenuItem.Text = "Exclude";
            excludeToolStripMenuItem.Click += excludeToolStripMenuItem_Click;
            // 
            // unionToolStripMenuItem
            // 
            unionToolStripMenuItem.Name = "unionToolStripMenuItem";
            unionToolStripMenuItem.Size = new Size(171, 22);
            unionToolStripMenuItem.Text = "Union";
            unionToolStripMenuItem.Click += unionToolStripMenuItem_Click;
            // 
            // xorToolStripMenuItem
            // 
            xorToolStripMenuItem.Name = "xorToolStripMenuItem";
            xorToolStripMenuItem.Size = new Size(171, 22);
            xorToolStripMenuItem.Text = "Xor";
            xorToolStripMenuItem.Click += xorToolStripMenuItem_Click;
            // 
            // entersectToolStripMenuItem
            // 
            entersectToolStripMenuItem.Name = "entersectToolStripMenuItem";
            entersectToolStripMenuItem.Size = new Size(171, 22);
            entersectToolStripMenuItem.Text = "Intersect";
            entersectToolStripMenuItem.Click += entersectToolStripMenuItem_Click;
            // 
            // exclToolStripMenuItem
            // 
            exclToolStripMenuItem.Name = "exclToolStripMenuItem";
            exclToolStripMenuItem.Size = new Size(171, 22);
            exclToolStripMenuItem.Text = "Excl";
            exclToolStripMenuItem.Click += exclToolStripMenuItem_Click;
            // 
            // clippingToolStripMenuItem
            // 
            clippingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { excludeClipToolStripMenuItem, setClipToolStripMenuItem, translateClipToolStripMenuItem });
            clippingToolStripMenuItem.Name = "clippingToolStripMenuItem";
            clippingToolStripMenuItem.Size = new Size(64, 20);
            clippingToolStripMenuItem.Text = "Clipping";
            // 
            // excludeClipToolStripMenuItem
            // 
            excludeClipToolStripMenuItem.Name = "excludeClipToolStripMenuItem";
            excludeClipToolStripMenuItem.Size = new Size(141, 22);
            excludeClipToolStripMenuItem.Text = "ExcludeClip";
            excludeClipToolStripMenuItem.Click += excludeClipToolStripMenuItem_Click;
            // 
            // setClipToolStripMenuItem
            // 
            setClipToolStripMenuItem.Name = "setClipToolStripMenuItem";
            setClipToolStripMenuItem.Size = new Size(141, 22);
            setClipToolStripMenuItem.Text = "SetClip";
            setClipToolStripMenuItem.Click += setClipToolStripMenuItem_Click;
            // 
            // translateClipToolStripMenuItem
            // 
            translateClipToolStripMenuItem.Name = "translateClipToolStripMenuItem";
            translateClipToolStripMenuItem.Size = new Size(141, 22);
            translateClipToolStripMenuItem.Text = "TranslateClip";
            translateClipToolStripMenuItem.Click += translateClipToolStripMenuItem_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(308, 114);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(431, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(308, 185);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(431, 23);
            textBox2.TabIndex = 2;
            // 
            // Regions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Regions";
            Text = "Regions";
            Paint += Regions_Paint;
            MouseDown += Regions_MouseDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem rectangleToolStripMenuItem;
        private ToolStripMenuItem roundTruncateAndOtherMethodsToolStripMenuItem;
        private ToolStripMenuItem containsToolStripMenuItem;
        private ToolStripMenuItem rectangeFToolStripMenuItem;
        private ToolStripMenuItem regionToolStripMenuItem;
        private ToolStripMenuItem constructToolStripMenuItem;
        private ToolStripMenuItem complementToolStripMenuItem;
        private ToolStripMenuItem emptyAndOthersToolStripMenuItem;
        private ToolStripMenuItem excludeToolStripMenuItem;
        private ToolStripMenuItem unionToolStripMenuItem;
        private ToolStripMenuItem xorToolStripMenuItem;
        private ToolStripMenuItem entersectToolStripMenuItem;
        private ToolStripMenuItem exclToolStripMenuItem;
        private ToolStripMenuItem clippingToolStripMenuItem;
        private ToolStripMenuItem excludeClipToolStripMenuItem;
        private ToolStripMenuItem setClipToolStripMenuItem;
        private ToolStripMenuItem translateClipToolStripMenuItem;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}