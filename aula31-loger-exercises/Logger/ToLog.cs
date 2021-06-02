using System;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
public class ToLogAttribute : Attribute {

    public ToLogAttribute(string label = "") {

    }

    public ToLogAttribute(Type formatterType, params string[] ctorArgs) {
        
    }
}