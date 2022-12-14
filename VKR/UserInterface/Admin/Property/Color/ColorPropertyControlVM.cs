using System.Linq;
using System.Windows;
using System.Collections.Generic;

using DataAccess.Data;
using DataAccess.Models;

using Microsoft.EntityFrameworkCore;

using VKR.Utils;
using VKR.Utils.Dialog;
using VKR.View;

using MessageBox = HandyControl.Controls.MessageBox;


namespace VKR.ViewModel;

public class ColorPropertyControlVM : ViewModelBase
{
    #region Functions

    #region Constructors

    public ColorPropertyControlVM(CounterfeitKBContext context, DialogService ds)
    {
        _context = context;
        //_context.Colors.Load();
        _ds = ds;
    }

    #endregion

    #endregion


    #region Properties

    private DialogService _ds;

    private readonly CounterfeitKBContext _context;
    public Color SelectedColor { get; set; }
    public List<Color> Colors
    {
        get => _context.Colors.ToList();
    }

    #endregion


    #region Commands

    private RelayCommand _addColor;

    /// <summary>
    ///     Команда, открывающая окно создания цвета
    /// </summary>
    public RelayCommand AddColor
    {
        get
        {
            return _addColor ??= new RelayCommand(o =>
            {
                _ds.ShowDialog<ColorPropertyEditControl>(
                windowParameters: new WindowParameters
                {
                    Height = 300,
                    Width = 300,
                    Title = "Добавление цвета"
                },
                data: new Color()
                {

                });
                OnPropertyChanged(nameof(Colors));
            });
        }
    }

    private RelayCommand _editColor;

    /// <summary>
    ///     Команда, открывающая окно редактирования цвета
    /// </summary>
    public RelayCommand EditColor
    {
        get
        {
            return _editColor ??= new RelayCommand(o =>
            {
                _ds.ShowDialog<ColorPropertyEditControl>(
                windowParameters: new WindowParameters
                {
                    Height = 300,
                    Width = 300,
                    Title = "Добавление цвета"
                },
                data: SelectedColor);
                OnPropertyChanged(nameof(Colors));
            }, _ => SelectedColor != null);
        }
    }

    private RelayCommand _deleteColor;

    /// <summary>
    ///     Команда, удаляющая цвет
    /// </summary>
    public RelayCommand DeleteColor
    {
        get
        {
            return _deleteColor ??= new RelayCommand(o =>
            {
                if (MessageBox.Show($"Вы действительно хотите удалить цвет: \"{SelectedColor.Name}\" и все фальсификаты связанные с ним?" +
                                    $"\nСвязанные фальсфикаты:\n{string.Join("\n", _context.Counterfeits.Where(c => c.ColorId == SelectedColor.Id).Include(c => c.Color).Select(c => c.Name))}",
                                    "Удаление цвета", MessageBoxButton.YesNo, MessageBoxImage.Warning) ==
                    MessageBoxResult.Yes)
                {
                    _context.Colors.Remove(SelectedColor);
                    _context.SaveChanges();
                }
                OnPropertyChanged(nameof(Colors));
            }, _ => SelectedColor != null);
        }
    }

    #endregion
}
