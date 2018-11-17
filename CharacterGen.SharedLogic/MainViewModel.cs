using CharacterGen.DataStorage;
using CharacterGen.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CharacterGen.SharedLogic
{
    public class MainViewModel
    {
        //private readonly IDataStructure dataStore;
        //public IDataStructure DataStore => dataStore;


        public MainViewModel()
        {
            //dataStore = db ?? throw new ArgumentNullException(nameof(db));
            Characters = new ObservableCollection<Character>();
        }

        private string message = "Add a Character";
        public string Message
        {
            get { return message; }
            set { SetField(ref message, value); }
        }

        private string firstname;
        public string FirstName
        {
            get { return firstname; }
            set { SetField(ref firstname, value); }
        }

        private string lastname;
        public string LastName
        {
            get { return lastname; }
            set { SetField(ref lastname, value); }
        }

        public ObservableCollection<Character> Characters { get; private set; }

        private ICommand addCharacter;
        public ICommand AddCharacter => addCharacter ?? (addCharacter = new SimpleCommand(() =>
        {
            Characters.Add(new Character { FirstName = FirstName, LastName = LastName });
            //DataStore.AddCharacter(new Character { FirstName = FirstName, LastName = LastName });
            //Characters.Clear();
            //foreach (Character c in DataStore.GetAllCharacters())
            //    Characters.Add(c);
            //if (repo.AddCard(new Character { FirstName = FirstName, LastName = LastName }))
            //    IsClosed = true;
        }));

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
