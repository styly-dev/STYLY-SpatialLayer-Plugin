using System.Collections;
using System.Collections.Generic;
using Codice.Client.Common.Locks;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Styly.VisionOs.Plugin.VisualScripting
{
    [UnitCategory("STYLY/System")]
    [UnitTitle("Get Url Parameter")]
    [UnitSubtitle("STYLY")]
    public class GetUrlParameterUnit : Unit
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
                resultValue = StylyUrlParameter.Get(keystr);
                return resultValue;
            });
        }
    }
    
    [Descriptor(typeof(GetUrlParameterUnit))]
    public class GetUrlParameterUnitDescriptor : UnitDescriptor<GetUrlParameterUnit>
    {
        public GetUrlParameterUnitDescriptor(GetUrlParameterUnit unit) : base(unit) {}

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
            if (port == unit.key)
            {
                description.summary = "The name of the parameter in the query string. ";
            }else if (port == unit.value)
            {
                description.summary = "The data or value associated with a specific key in the query string.";
            }
        }
    }
    
    [UnitCategory("STYLY/System")]
    [UnitTitle("Get Url Parameter List")]
    [UnitSubtitle("STYLY")]
    public class GetUrlParameterListUnit : Unit
    {
        // vale output port
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueOutput value;
        
        private List<string> resultValue;

        protected override void Definition() //The method to set what our node will be doing.
        {
            value = ValueOutput<List<string>>("Param List", (flow) =>
            {
                resultValue = StylyUrlParameter.GetParameterList();
                return resultValue;
            });
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