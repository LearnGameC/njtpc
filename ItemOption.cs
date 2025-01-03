public class ItemOption
{
	public int param;

	public sbyte active;

	public ItemOptionTemplate optionTemplate;

	public ItemOption()
	{
	}

	public ItemOption(int optionTemplateId, int param)
	{
		this.param = param;
		optionTemplate = GameScr.iOptionTemplates[optionTemplateId];
	}

	public string getOptionString()
	{
		if (optionTemplate.type == 9)
		{
			string valuePercent = getValuePercent(param);
			return NinjaUtil.replace(optionTemplate.name, "#", valuePercent);
		}
		return NinjaUtil.replace(optionTemplate.name, "#", param + string.Empty);
	}

	public string getValuePercent(int value)
	{
		if (value % 100 == 0)
		{
			return value / 100 + string.Empty;
		}
		if (value % 10 == 0)
		{
			return value / 100 + "." + value % 100 / 10;
		}
		return value / 100 + "." + value % 100 / 10 + string.Empty + value % 10;
	}

	public string getOptionShopString()
	{
		string empty = string.Empty;
		int num = 0;
		if (optionTemplate.id == 0 || optionTemplate.id == 1 || optionTemplate.id == 21 || optionTemplate.id == 22 || optionTemplate.id == 23 || optionTemplate.id == 24 || optionTemplate.id == 25 || optionTemplate.id == 26)
		{
			num = param - 50 + 1;
			return NinjaUtil.replace(optionTemplate.name, "#", param + string.Empty) + " (" + num + "-" + param + ")";
		}
		if (optionTemplate.id == 6 || optionTemplate.id == 7 || optionTemplate.id == 8 || optionTemplate.id == 9 || optionTemplate.id == 19)
		{
			num = param - 10 + 1;
			return NinjaUtil.replace(optionTemplate.name, "#", param + string.Empty) + " (" + num + "-" + param + ")";
		}
		if (optionTemplate.id == 2 || optionTemplate.id == 3 || optionTemplate.id == 4 || optionTemplate.id == 5 || optionTemplate.id == 10 || optionTemplate.id == 11 || optionTemplate.id == 12 || optionTemplate.id == 13 || optionTemplate.id == 14 || optionTemplate.id == 15 || optionTemplate.id == 17 || optionTemplate.id == 18 || optionTemplate.id == 20)
		{
			num = param - 5 + 1;
			return NinjaUtil.replace(optionTemplate.name, "#", param + string.Empty) + " (" + num + "-" + param + ")";
		}
		if (optionTemplate.id == 16)
		{
			num = param - 3 + 1;
			return NinjaUtil.replace(optionTemplate.name, "#", param + string.Empty) + " (" + num + "-" + param + ")";
		}
		return NinjaUtil.replace(optionTemplate.name, "#", param + string.Empty);
	}

	public string getOptionShopString1()
	{
		return NinjaUtil.replace(optionTemplate.name, "#", param + string.Empty);
	}
}
