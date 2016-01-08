using System;
using System.Collections.Generic;

using System.Text;


namespace x86
{
   internal class EWebBrowser : System.Windows.Forms.WebBrowser
  {
    private SHDocVw.IWebBrowser2 Iwb2;

    public EWebBrowser()
    {
      
    }

    protected override void AttachInterfaces(object nativeActiveXObject)
    {
      try
      {
        this.Iwb2 = (SHDocVw.IWebBrowser2) nativeActiveXObject;
        this.Iwb2.Silent = true;
        base.AttachInterfaces(nativeActiveXObject);
      }
      catch
      {
      }
    }

    protected override void DetachInterfaces()
    {
      try
      {
        this.Iwb2 = (SHDocVw.IWebBrowser2) null;
        base.DetachInterfaces();
      }
      catch
      {
      }
    }
  }
}