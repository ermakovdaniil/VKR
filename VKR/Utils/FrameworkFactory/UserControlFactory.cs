﻿using System.Windows;
using System.Windows.Controls;


namespace VKR.Utils.FrameworkFactory;

public class UserControlFactory
{
    private readonly IFrameworkElementFactory _frameworkElementFactory;

    public UserControlFactory(IFrameworkElementFactory frameworkElementFactory)
    {
        _frameworkElementFactory = frameworkElementFactory;
    }
    public UserControl CreateUserControl<T>(object param) where T : UserControl
    {
        return (UserControl) _frameworkElementFactory.CreateFrameworkElement<T>(param);
    }
}
