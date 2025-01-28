using System.Collections.Generic;
using Unity.VisualScripting;

namespace Styly.VisionOs.Plugin.VisualScripting
{
    [UnitCategory("STYLY/System")]
    [UnitTitle("GetSystemInfo")]
    public class GetSystemInfoUnit : Unit
    {
        // Flow input port
        public ControlInput triggerInput;

        // Flow output port
        public ControlOutput triggerOutput;
        
        // value input port
        [DoNotSerialize]
        public ValueInput key;

        // vale output port
        [DoNotSerialize]
        public ValueOutput value;
        
        private string resultValue;

        protected override void Definition() //The method to set what our node will be doing.
        {
            // フロー入力ポートの作成
            triggerInput = ControlInput("In", (flow) =>
            {
                return triggerOutput;
            });
            triggerOutput = ControlOutput("Out");
            
            key = ValueInput<string>("Key");
            value = ValueOutput<string>("Value", (flow) =>
            {
                string keystr = flow.GetValue<string>(key);
                resultValue = StylySystemInfo.GetInfo(keystr);
                return resultValue;
            });
        }
    }
    
    [UnitCategory("STYLY/System")]
    [UnitTitle("GetInfoNameList")]
    public class GetInfoNameListUnit : Unit
    {
        // Flow input port
        public ControlInput triggerInput;

        // Flow output port
        public ControlOutput triggerOutput;
        
        // vale output port
        [DoNotSerialize]
        public ValueOutput value;
        
        private List<string> resultValue;

        protected override void Definition() //The method to set what our node will be doing.
        {
            // フロー入力ポートの作成
            triggerInput = ControlInput("In", (flow) =>
            {
                return triggerOutput;
            });
            triggerOutput = ControlOutput("Out");
            
            value = ValueOutput<List<string>>("Value", (flow) =>
            {
                resultValue = StylySystemInfo.GetInfoNameList();
                return resultValue;
            });
        }
    }
}
