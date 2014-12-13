using System;
using Cirrious.MvvmCross.Views;

namespace SplitContainerSample.Touch.Views
{
    public interface IPadContainer
    {
        bool ShowView(IMvxView view);
    }
}

