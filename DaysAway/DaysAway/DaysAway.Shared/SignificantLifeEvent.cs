using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Windows.UI.Xaml;

namespace DaysAway
{
    public class SignificantLifeEvent : DependencyObject, INotifyPropertyChanged
    {
        #region Dependency Properties
        public static readonly DependencyProperty EndDateProperty = DependencyProperty.Register("EndDate", typeof(DateTime), typeof(SignificantLifeEvent), new PropertyMetadata(default(DateTime), OnEndDateChangedStatic));
        public static readonly DependencyProperty StartDateProperty = DependencyProperty.Register("StartDate", typeof(DateTime), typeof(SignificantLifeEvent), new PropertyMetadata(default(DateTime), OnStartDateChangedStatic));
        #endregion

        #region Property Accessors
        public DateTime EndDate
        {
            get { return (DateTime)GetValue(EndDateProperty); }
            set { SetValue(EndDateProperty, value); }
        }

        public DateTime StartDate
        {
            get { return (DateTime)GetValue(StartDateProperty); }
            set { SetValue(StartDateProperty, value); }
        }

        public double Percentage
        {
            get { return (double)(DateTime.Now.Ticks - StartDate.Ticks) * 100.0 / (double)(EndDate.Ticks - StartDate.Ticks); }
        }

        public int DaysAway
        {
            get { return (EndDate - DateTime.Today).Days; }
        }

        public double WeeksAway
        {
            get { return (double)DaysAway / 7.0; }
        }

        public double MonthsAway
        {
            get { return (double)DaysAway / 30.0; }
        }

        public double YearsAway
        {
            get { return (double)DaysAway / 365.0; }
        }
        #endregion

        #region Property Change Handlers
        private static void OnEndDateChangedStatic(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            SignificantLifeEvent typedSender = (SignificantLifeEvent)sender;
            typedSender.OnPropertyChanged("EndDate");
            typedSender.OnPropertyChanged("Percentage");
            typedSender.OnPropertyChanged("DaysAway");
            typedSender.OnPropertyChanged("WeeksAway");
            typedSender.OnPropertyChanged("MonthsAway");
            typedSender.OnPropertyChanged("YearsAway");
        }

        private static void OnStartDateChangedStatic(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            SignificantLifeEvent typedSender = (SignificantLifeEvent)sender;
            typedSender.OnPropertyChanged("StartDate");
            typedSender.OnPropertyChanged("DaysAway");
            typedSender.OnPropertyChanged("WeeksAway");
            typedSender.OnPropertyChanged("MonthsAway");
            typedSender.OnPropertyChanged("YearsAway");
        }
        #endregion

        #region Methods
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }

}
