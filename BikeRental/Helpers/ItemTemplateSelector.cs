using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace BikeRental.View
{
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BikeTemplate { get; set; }
        public DataTemplate ReviewTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Bike)
                return BikeTemplate;
            else if (item is Review)
                return ReviewTemplate;
            else
                return base.SelectTemplate(item, container);
        }
    }


}
