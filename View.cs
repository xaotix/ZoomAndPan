using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZoomAndPan
{
   public static class View
    {

        public static void Open(List<UIElement> objs, string title = "", double w = 1500, double h = 1000 )
        {
            Viewer.ViewCanvas mm = new Viewer.ViewCanvas();
            mm.Title = title;
            if(w>0)
            {
            mm.canvas.GetCanvas().Width = w;
            }
            if(h>0)
            {
            mm.canvas.GetCanvas().Height = h;
            }
            mm.canvas.Populate(objs);
            mm.Show();
            

        }
    }
}
