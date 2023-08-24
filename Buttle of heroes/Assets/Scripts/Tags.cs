public enum Tags
{
    FIELD,
    UNIT,
    UNKNOWN
}

public static class TagsMethods
{
    public static string ToString(Tags tags)
    {
        switch (tags)
        {
            case Tags.FIELD: return "Field";
            case Tags.UNIT: return "Unit";
            default: return "";
        }
    }

    public static Tags ToTag(string tag)
    {
        switch (tag)
        {
            case "Field": return Tags.FIELD;
            case "Unit": return Tags.UNIT;
            default: return Tags.UNKNOWN;
        }
    }
}
