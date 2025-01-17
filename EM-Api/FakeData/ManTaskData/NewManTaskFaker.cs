﻿using Bogus;
using Shared.Modelviews.ManTask;

namespace FakeData.ManTaskData
{
    public class NewManTaskFaker: Faker<NewEvent>
    {
        public NewManTaskFaker()
        {
            RuleFor(x => x.Description, df => df.Commerce.ProductDescription());
            RuleFor(x => x.CollaboratorName, df => df.Person.FullName);
            RuleFor(x => x.Comments, df => df.Company.CompanyName());
            RuleFor(x => x.StartDate, df => df.Date.Past());
            RuleFor(x => x.EndDate, df => df.Date.Past());
        }
    }
}
