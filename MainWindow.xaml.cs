using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🙉", "🙉",
                "🐶", "🐶",
                "🐷", "🐷",
                "🐮", "🐮",
                "🐼", "🐼",
                "🐞", "🐞",
                "🦄", "🦄",
                "🐹", "🐹",
            };

            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                var index = random.Next(animalEmoji.Count);

                var emoji = animalEmoji[index];

                textBlock.Text = emoji;

                animalEmoji.RemoveAt(index);
            }
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            // condition for the first click 
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
                return;
            }

            // condition for the second click - check if matched
            var itemMatched = textBlock.Text == lastTextBlockClicked.Text;
            if (itemMatched)
            {
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            } else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }



        // handle click

        // step 1: the user click on one of the textblock.

        // step 2: first animal will appears then disappear. firstIndex

        // step 3: the user click on the second textblock.

        // step 4: second animal appears. secondIndex
        /* check if match
         * if (firstIndex == secondIndex) 
         * {
         *   firstIndex will reappear
         *   
         * } else {
         *   firstIndex && secondIndex will disappear
         * 
         * }
         * 
         * 
         * 
         */

    }
}
