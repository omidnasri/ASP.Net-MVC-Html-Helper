using System.Collections.Generic;

namespace PTCCommon
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Init();
        }

        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public string Mode { get; set; }

        public bool IsValid { get; set; }

        public string EventCommand { get; set; }

        public string EventArgument { get; set; }

        public bool IsDetailAreaVisible { get; set; }

        public bool IsListAreaVisible { get; set; }

        public bool IsSearchAreaVisible { get; set; }

        protected virtual void Init()
        {
            EventCommand = "List";
            EventArgument = string.Empty;
            ListMode();
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }

        protected virtual void Get()
        {
        }

        public virtual void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "add":
                    Add();
                    break;

                case "edit":
                    IsValid = true;
                    Edit();
                    break;

                case "delete":
                    ResetSearch();
                    Delete();
                    break;

                case "save":
                    Save();
                    Get();
                    break;

                case "cancel":
                    ListMode();
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;
            }
        }

        protected virtual void ListMode()
        {
            Mode = "List";
            IsValid = true;
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;
        }

        protected virtual void AddMode()
        {
            IsDetailAreaVisible = true;
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;

            Mode = "Add";
        }

        protected virtual void EditMode()
        {
            IsDetailAreaVisible = true;
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;

            Mode = "Edit";
        }

        protected virtual void Add()
        {

            // Put ViewModel into Add Mode
            AddMode();
        }

        protected virtual void Edit()
        {

            // Put View Model into Edit Mode
            EditMode();
        }

        protected virtual void Delete()
        {

            // Set back to normal mode
            ListMode();
        }

        protected virtual void Save()
        {
            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }

            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
                else
                {
                    EditMode();
                }
            }
        }

        protected virtual void ResetSearch()
        {
        }
    }
}