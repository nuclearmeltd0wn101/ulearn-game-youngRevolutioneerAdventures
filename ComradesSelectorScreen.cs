﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ulearn_game_YoungRevolutioneerGame
{
enum ComradeSelectorAction
    {
        RefreshOptions,
        Clear
    }
        
    public class ComradesSelectorScreen : IScreen
    {
        private const int ComradesPerScreenCount = 3;
        private static readonly Point[] ComradeDetailsLocations = new[]
        {
            new Point(13, 70),
            new Point(283, 70),
            new Point(553, 70)
        };
        private static readonly Point[] SelectButtonsLocations = new[]
        {
            new Point(50, 482),
            new Point(320, 482),
            new Point(590, 482)
        };

        private ComradesSelectorModel model;
        private Form form;
        Button[] selectButtons = new Button[ComradesPerScreenCount];
        PictureBox[] comradeDetails = new PictureBox[ComradesPerScreenCount];

        public void Initialize(Form form)
        {
            this.form = form;

            for (var i = 0; i < ComradesPerScreenCount; i++)
            {
                var j = i;
                selectButtons[i] = new Button
                {
                    Size = new Size(145, 40),
                    Location = SelectButtonsLocations[i],
                    Image = Properties.Resources.SelectButton,
                    FlatStyle = FlatStyle.Flat
                };
                comradeDetails[i] = new PictureBox
                {
                    Size = new Size(235, 390),
                    Location = ComradeDetailsLocations[i]
                };
                selectButtons[i].FlatAppearance.BorderSize = 0;
                selectButtons[i].Click += (o, e) => model.Choose(j);
            }

            model = new ComradesSelectorModel(this);
        }

        public void LoadComradeDetails(Image[] details)
        {
            for (var i = 0; i < ComradesPerScreenCount; i++)
                comradeDetails[i].Image = details[i];
        }

        public void Draw()
        {
            form.BackgroundImage = Properties.Resources.ComradesSelectorBg;
            foreach (var button in selectButtons)
                form.Controls.Add(button);
            foreach (var pb in comradeDetails)
                form.Controls.Add(pb);
        }

        public void Clear()
        {
            form.BackgroundImage = default;
            foreach (var button in selectButtons)
                form.Controls.Remove(button);
            foreach (var pb in comradeDetails)
                form.Controls.Remove(pb);
        }

    }
}
