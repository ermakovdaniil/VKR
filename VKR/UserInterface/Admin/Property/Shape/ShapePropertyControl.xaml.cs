﻿using System.Windows.Controls;

using Autofac;

using VKR.ViewModel;


namespace VKR.View;

/// <summary>
///     Логика взаимодействия для ShapePropertyControl.xaml
/// </summary>
public partial class ShapePropertyControl : UserControl
{
    private ShapePropertyControlVM _viewModel;
    
    public ShapePropertyControl(ShapePropertyControlVM vm)
    {
        InitializeComponent();
        DataContext = vm;
        _viewModel = vm;
    }

    public IContainer Container { get; set; }
}
