using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Styly.VisionOs.Plugin.VisualScripting
{
    [UnitCategory("STYLY/System")]
    [UnitTitle("GetUrlParameter")]
    public class GetUrlParameterUnit : Unit
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
                resultValue = StylyUrlParameter.Get(keystr);
                return resultValue;
            });
        }
    }
    
    
    [UnitCategory("STYLY/System")]
    [UnitTitle("GetUrlParameterList")]
    public class GetUrlParameterListUnit : Unit
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
                resultValue = StylyUrlParameter.GetParameterList();
                return resultValue;
            });
        }
    }
}