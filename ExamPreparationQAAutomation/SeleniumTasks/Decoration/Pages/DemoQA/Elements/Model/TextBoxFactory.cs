using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTasks.Decoration.Pages.DemoQA.Elements.Model
{
    public class TextBoxFactory
    {
        public static TextBoxModel Create()
        {
            return new TextBoxModel
            {
                userEmail = "peshka@abv.bg",
                userName = "Pesh",
                currentAddress = "Kuku Buku"
            };
        }
    }
}
