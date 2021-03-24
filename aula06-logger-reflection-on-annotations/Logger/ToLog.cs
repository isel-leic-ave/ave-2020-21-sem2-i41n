using System;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
public class ToLogAttribute : Attribute {

    public ToLogAttribute(string label = "") {

    }
}