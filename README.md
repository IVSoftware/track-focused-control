# Track Focused Control

Your code seems basically ok but you would want to make sure that you iterated all the children (of all the children...) of your Control tree as well.

[![combo, textbox etc in panel][1]][1]

```
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
```
**Iterator**

```
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
```


  [1]: https://i.stack.imgur.com/vjKYY.png
