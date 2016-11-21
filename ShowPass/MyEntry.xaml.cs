﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShowPass
{
    public partial class MyEntry : ContentView
    {
        const string Show = "SHOW";
        const string Hide = "HIDE";

        public MyEntry ()
        {
            InitializeComponent ();
        }

        public static BindableProperty TextProperty = BindableProperty.Create (nameof (Text), typeof (string), typeof (MyEntry), default (string));

        public string Text {
            get { return (string)GetValue (TextProperty); }
            set { SetValue (TextProperty, value); }
        }

        public static BindableProperty PlaceholderProperty = BindableProperty.Create (nameof (Placeholder), typeof (string), typeof (MyEntry), default(string));

        public string Placeholder {
            get { return (string)GetValue (PlaceholderProperty); }
            set { SetValue (PlaceholderProperty, value); }
        }

        public static BindableProperty IsPasswordProperty = BindableProperty.Create (nameof (IsPassword), typeof (bool), typeof (MyEntry), default (bool), propertyChanged:IsPasswordChanged);

        public bool IsPassword {
            get { return (bool)GetValue (IsPasswordProperty); }
            set { SetValue (IsPasswordProperty, value); }
        }

        static void IsPasswordChanged (BindableObject bindable, object oldValue, object newValue)
        {
            var me = bindable as MyEntry;
            me.IsPasswordEntry = (bool)newValue;
        }

        public static BindableProperty IsPasswordEntryProperty = BindableProperty.Create (nameof (IsPasswordEntry), typeof (bool), typeof (MyEntry), default (bool));

        public bool IsPasswordEntry {
            get { return (bool)GetValue (IsPasswordEntryProperty); }
            set { SetValue (IsPasswordEntryProperty, value); }
        }

        private string _toggleText = Show;
        public string ToggleText {
            get { return _toggleText; }
            set {
                _toggleText = value;
                OnPropertyChanged ();
            }
        }

        public ICommand ShowPasswordCommand => new Command (OnToggleTapped);

        void OnToggleTapped (object obj)
        {
            if (string.Equals (ToggleText, Show)) {
                ToggleText = Hide;
                IsPasswordEntry = false;
            } else {
                ToggleText = Show;
                IsPasswordEntry = true;
            }
        }

    }
}
