using System;
using System.Collections.Generic;
using PTCCommon;

namespace PTCData
{
    public class TrainingProductViewModel : ViewModelBase
    {
        public TrainingProductViewModel()
        {
            // Initialize other variables
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();
        }

        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity { get; set; }
        public TrainingProduct Entity { get; set; }

        protected override void Init()
        {
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();

            base.Init();
        }

        public override void HandleRequest()
        {
            // This is an example of adding on a new command
            switch (EventCommand.ToLower())
            {
                case "newcommand":
                    break;

            }

            base.HandleRequest();
        }

        protected override void Add()
        {
            IsValid = true;

            // Initialize Entity Object
            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = string.Empty;
            Entity.Price = 0;

            base.Add();
        }

        protected override void Edit()
        {
            TrainingProductManager mgr =
             new TrainingProductManager();

            // Get Product Data
            Entity = mgr.Get(
              Convert.ToInt32(EventArgument));

            base.Edit();
        }

        protected override void Save()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            if (Mode == "Add")
            {
                mgr.Insert(Entity);
            }
            else
            {
                mgr.Update(Entity);
            }

            // Set any validation errors
            ValidationErrors = mgr.ValidationErrors;

            // Set mode based on validation errors
            base.Save();
        }

        protected override void Delete()
        {
            TrainingProductManager mgr =
              new TrainingProductManager();

            // Create new entity
            Entity = new TrainingProduct();

            // Get primary key from EventArgument
            Entity.ProductId =
              Convert.ToInt32(EventArgument);

            // Call data layer to delete record
            mgr.Delete(Entity);

            // Reload the Data
            Get();

            base.Delete();
        }

        protected override void ResetSearch()
        {
            SearchEntity = new TrainingProduct();

            base.ResetSearch();
        }

        protected override void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Products = mgr.Get(SearchEntity);

            base.Get();
        }
    }
}