﻿

internal class CafeMenu : ICafeMenu
{
	public virtual int Id { get; set; }
	public string ItemName { get; set; }
	public float ItemPrice { get; set; }
	public List<string>? Ingredients { get; set; }
}

