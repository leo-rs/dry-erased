using MvvmCross.ViewModels;
using MvxStarter.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxStarter.Core.ViewModels
{
    public class GuestBookViewModel : MvxViewModel
    {
        private ObservableCollection<PersonModel> _people = new ObservableCollection<PersonModel>();

        public ObservableCollection<PersonModel> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                SetProperty(ref _firstName, value);
                RaisePropertyChanged(() => FullName);
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                SetProperty(ref _lastName, value);
                RaisePropertyChanged(() => FullName);
            }
        }

        public string FullName => $"{ FirstName } { LastName }";

    }
}
