﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Avalonia.Data.Converters;
using Avalonia.Media;
using AvalonStudio.Extensibility.Theme;
using WalletWasabi.Models;

namespace WalletWasabi.Gui.Converters
{
	public class StatusColorConvertor : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch (parameter.ToString())
			{
				case "Tor" when Enum.Parse<TorStatus>(value.ToString()) == TorStatus.NotRunning:
				case "Backend" when Enum.Parse<BackendStatus>(value.ToString()) == BackendStatus.NotConnected:
				case "Peers" when (int)value == 0:
				case "FiltersLeft" when value.ToString() != "0": // need to cover "--"
				case "BlocksLeft" when (int)value != 0:
					return Brushes.Yellow;
				default:
					return ColorTheme.CurrentTheme.Foreground;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
