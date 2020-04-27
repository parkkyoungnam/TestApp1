using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestApp1.Model;
using Xamarin.Forms;

namespace TestApp1.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {

            RegistCommand = new Command(Regist);
            ModifyCommand = new Command<string>(Modify);
            DeleteCommand = new Command(Delete);

            this.UserID = "Eddy.Kang";
            this.UserName = "강창훈";
            this.Email = "admin@signalsoft.co.kr";
            this.Telephone = "010-2760-5246";
            this.RegistDate = DateTime.Now;
        }

        public ICommand RegistCommand { get; private set; }
        public ICommand ModifyCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        private async void Regist()
        {
            UserModel user = new UserModel();
            user.UserID = this.UserID;
            user.UserName = this.UserName;
            user.Email = this.Email;
            user.Telephone = this.Telephone;
            user.RegistDate = DateTime.Now;

            string baseApiAddress = "http://mixedcode.com/api/user/";
            HttpClient client = new HttpClient();

            var uri = new Uri(baseApiAddress);
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);
            var result = response.IsSuccessStatusCode;

            GetUserListBind();
        }


        //사용자 목록조회

        public void GetUserListBind()
        {
            string baseApi = "http://mixedcode.com/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseApi);
            client.MaxResponseContentBufferSize = 256000;

            var response = client.GetAsync("api/user/").Result;

            List<UserModel> users = null;

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UserModel>>(jsonResult);
                UserDataList = new ObservableCollection<UserModel>(users);
            }
        }

        //사용자데이터 목록 바인딩 속성정의
        private ObservableCollection<UserModel> _UserDataList;
        public ObservableCollection<UserModel> UserDataList
        {
            get
            {
                return _UserDataList;
            }

            set
            {
                _UserDataList = value;
                OnPropertyChanged("UserDataList");
            }
        }

        private void Modify(string commandPrameter)
        {
            var test = commandPrameter;
        }

        private void Delete()
        {

        }

        private string _UserID;
        public string UserID
        {
            get
            {
                return _UserID;
            }

            set
            {
                if (_UserID == value) return;
                _UserID = value;
                OnPropertyChanged("UserID");
            }
        }

        private string _UserName;
        public string UserName
        {
            get
            {
                return _UserName;
            }

            set
            {
                if (_UserName == value) return;
                _UserName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                if (_Email == value) return;
                _Email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _Telephone;
        public string Telephone
        {
            get
            {
                return _Telephone;
            }

            set
            {
                if (_Telephone == value) return;
                _Telephone = value;
                OnPropertyChanged("Telephone");
            }
        }

        private DateTime? _RegistDate;
        public DateTime? RegistDate
        {
            get
            {
                return _RegistDate;
            }

            set
            {
                if (_RegistDate == value) return;
                _RegistDate = value;
                OnPropertyChanged("RegistDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}