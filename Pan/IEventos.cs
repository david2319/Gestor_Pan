using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pan
{
    interface IEventos{
        void DragDropFile(object sender, System.Windows.Forms.DragEventArgs e);
        void DragEnterFile(object sender, System.Windows.Forms.DragEventArgs e);
    }
}
