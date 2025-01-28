using System;
using Unity.VisualScripting;


namespace Styly.VisionOs.Plugin.VisualScripting
{
    [Descriptor(typeof(GetUrlParameterUnit))]
    public class GetUrlParameterUnitDescriptor : UnitDescriptor<GetUrlParameterUnit>
    {
        public GetUrlParameterUnitDescriptor(GetUrlParameterUnit unit) : base(unit)
        {
        }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
            if (port == unit.key)
            {
                description.summary = "The name of the parameter in the query string. ";
            }
            else if (port == unit.value)
            {
                description.summary = "The data or value associated with a specific key in the query string.";
            }
        }
    }
    
    [Descriptor(typeof(GetUrlParameterListUnit))]
    public class GetUrlParameterListUnitDescriptor : UnitDescriptor<GetUrlParameterListUnit>
    {
        public GetUrlParameterListUnitDescriptor(GetUrlParameterListUnit unit) : base(unit) {}

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
            
            if (port == unit.value)
            {
                description.summary = "Retrieves a list of all parameter names (keys) present in the query string of a URL.";
            }
        }
    }
}