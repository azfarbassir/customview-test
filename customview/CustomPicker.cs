using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;

namespace customview
{
    [Register("CustomPicker")]
    public class CustomPicker : UIView, IComponent
    {
        public CustomPicker(IntPtr p) : base(p)
        {
        }

        public ISite Site { get; set; }

        public event EventHandler Disposed;

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            using (var g = UIGraphics.GetCurrentContext())
            {
                var label = new UIPickerView(new CGRect(rect.X, rect.Y, rect.Width, rect.Height));
                label.Model = new PeopleModel();
                AddSubview(label);
            }
        }
    }

    public class PeopleModel : UIPickerViewModel
    {
        public string[] names = new string[] {
            "Amy Burns",
            "Kevin Mullins",
            "Craig Dunn",
            "Joel Martinez",
            "Charles Petzold",
            "David Britch",
            "Mark McLemore",
            "Tom Opegenorth",
            "Joseph Hill",
            "Miguel De Icaza"
        };

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return names.Length;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return names[row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
        }

        public override nfloat GetComponentWidth(UIPickerView picker, nint component)
        {
            return 240f;
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 40f;
        }
    }
}
