namespace track_focused_control
{
    public partial class BillingMetal : Form
    {
        public BillingMetal()
        {
            InitializeComponent();
            foreach (var ctrl in IterateControls(Controls))
            {
                ctrl.GotFocus += (sender, e) =>
                { 
                    if(sender is Control ctrl)
                    {
                        ctrl.Tag = ctrl.BackColor;
                        ctrl.BackColor = Color.Red;
                    }
                };
                ctrl.LostFocus += (sender, e) =>
                {
                    if(sender is Control ctrl && ctrl.Tag is Color color)
                    {
                        ctrl.BackColor = color;
                    }
                };
            }
        }
        IEnumerable<Control> IterateControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                yield return control;
                foreach (Control child in IterateControls(control.Controls))
                {
                    yield return child;
                }
            }
        }
    }
}
