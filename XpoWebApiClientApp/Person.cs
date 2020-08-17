using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace XpoWebApiClientApp
{
    public class Person:DevExpress.Xpo.XPObject
    {
        protected Person()
        {

        }

        public Person(Session session) : base(session)
        {

        }

        public Person(Session session, XPClassInfo classInfo) : base(session, classInfo)
        {

        }

        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
    }
}
