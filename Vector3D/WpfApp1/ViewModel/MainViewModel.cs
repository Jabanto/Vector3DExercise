using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Common;
using Vector3DLibraries;
using System.Diagnostics;

namespace WpfApp1.ViewModel
{
    /// <summary>
    /// This ViewModel is the component that is responsible for handling 
    /// the main application's presentation<see cref="MainWindow"/> logic and state,expose de dta to the view,
    /// define the commands or command parameters implementation and bound the properties exposed here with the UI elements
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Properties

        // --------- Implemntation of INotifyPropertyChanged ---------
        public event PropertyChangedEventHandler PropertyChanged;

        // --------- Log --------

        private static TraceSource ts = new TraceSource("TraceTest");

        //--------- ICommand Buttons fields ---------

        private ICommand _closeMainViewCommand;
        private ICommand _calculateViewCommand;

        private string _angleText= "Insert Vectors";
        private string _crossProductText = "Insert Vectors";

        private string _magnitudVectorAText = "MagA";
        private string _magnitudVectorBText = "MagB";

        private Vector3D vector3D1;
        private Vector3D vector3D2;

        private double _XaValue;
        private double _YaValue;
        private double _ZaValue;

        private double _XbValue;
        private double _YbValue;
        private double _ZbValue;

        #endregion

        public MainViewModel()
        {
            
        }

        #region Public Methods

        public string AngleText
        {
            get { return this._angleText; }
            set
            {
                this._angleText = value;
                RaisePropertyChanged("AngleText");
            }
        }

        public string MagnitudVectorBText
        {
            get { return this._magnitudVectorBText; }
            set
            {
                this._magnitudVectorBText = value;
                RaisePropertyChanged("MagnitudVectorBText");
            }
        }

        public string MagnitudVectorAText
        {
            get { return this._magnitudVectorAText; }
            set
            {
                this._magnitudVectorAText = value;
                RaisePropertyChanged("MagnitudVectorAText");
            }
        }


        public string CrossProductText
        {
            get { return this._crossProductText; }
            set
            {
                this._crossProductText = value;
                RaisePropertyChanged("CrossProductText");
            }
        }
        public ICommand CloseMainViewCommand
        {
            get
            {
                if (_closeMainViewCommand == null)
                {
                    _closeMainViewCommand = new RelayCommand(p => ExecuteCloseMainWindowCommand());
                }
                return _closeMainViewCommand;
            }
        }

        public ICommand CalculateViewCommand
        {
            get
            {
                if (_calculateViewCommand == null)
                {
                    _calculateViewCommand = new RelayCommand(p => ExecuteCalculateCommand(p));
                }
                return _calculateViewCommand;
            }
        }


        public void ExecuteCalculateCommand(object parameter)
        {
            var values = (object[])parameter;
            if (values.Count() != 0 && values[0] != null)
            {
                _XaValue = Convert.ToDouble(values[0]);
                _YaValue = Convert.ToDouble(values[1]);
                _ZaValue = Convert.ToDouble(values[2]);

                _XbValue = Convert.ToDouble(values[3]);
                _YbValue = Convert.ToDouble(values[4]);
                _ZbValue = Convert.ToDouble(values[5]);

                vector3D1 = new Vector3D(_XaValue, _YaValue, _ZaValue);
                vector3D2 = new Vector3D(_XbValue, _YbValue, _ZbValue);

                this.CrossProductText = string.Join(", ", vector3D1.CrossProduct(vector3D2).ArrayVector);
                this.MagnitudVectorAText = Math.Round(vector3D1.Magnitude,4).ToString();
                this.MagnitudVectorBText = Math.Round(vector3D2.Magnitude,4).ToString();
                double resultAngleAB = Math.Round(vector3D1.Angle(vector3D2), 4);
                this.AngleText = Math.Round(((resultAngleAB * 180) / Math.PI),4).ToString();  
            }
            else
            {
                ts.TraceEvent(TraceEventType.Error, 1, "Something happens calculating, check values");
                ts.Close();
            }

        }
        public void ExecuteCloseMainWindowCommand()
        {
            DialogFunctions.CloseViewByName("MainView");
        }

        public void RaisePropertyChanged(string name)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
    #endregion

}
