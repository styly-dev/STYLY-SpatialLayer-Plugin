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
}
