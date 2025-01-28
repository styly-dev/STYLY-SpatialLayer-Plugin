using System.Collections.Generic;
using Unity.VisualScripting;

namespace Styly.VisionOs.Plugin.VisualScripting
{
    [UnitCategory("STYLY/System")]
    [UnitTitle("Get System Info")]
    [UnitSubtitle("STYLY")]
    public class GetSystemInfoUnit : Unit
    {
        // value input port
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput key;

        // vale output port
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueOutput value;
        
        private string resultValue;

        protected override void Definition() //The method to set what our node will be doing.
        {
            key = ValueInput<string>("Key", string.Empty);
            value = ValueOutput<string>("Value", (flow) =>
            {
                string keystr = flow.GetValue<string>(key);
                resultValue = StylySystemInfo.GetInfo(keystr);
                return resultValue;
            });
        }
    }
    
    [Descriptor(typeof(GetSystemInfoUnit))]
    public class GetSystemInfoUnitDescriptor : UnitDescriptor<GetSystemInfoUnit>
    {
        public GetSystemInfoUnitDescriptor(GetSystemInfoUnit unit) : base(unit) {}

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
            if (port == unit.key)
            {
                description.summary = "The identifier for the specific system information to retrieve.";
            }else if (port == unit.value)
            {
                description.summary = "The system information associated with the specified key.";
            }
        }
    }
    
    [UnitCategory("STYLY/System")]
    [UnitTitle("Get System Info List")]
    [UnitSubtitle("STYLY")]
    public class GetInfoNameListUnit : Unit
    {
        // vale output port
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueOutput value;
        
        private List<string> resultValue;

        protected override void Definition() //The method to set what our node will be doing.
        {
            value = ValueOutput<List<string>>("Info List", (flow) =>
            {
                resultValue = StylySystemInfo.GetInfoNameList();
                return resultValue;
            });
        }
    }
    
    [Descriptor(typeof(GetInfoNameListUnit))]
    public class GetInfoNameListUnitDescriptor : UnitDescriptor<GetInfoNameListUnit>
    {
        public GetInfoNameListUnitDescriptor(GetInfoNameListUnit unit) : base(unit) {}

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
            
            if (port == unit.value)
            {
                description.summary = "Retrieves a list of all available system information keys.";
            }
        }
    }
}
