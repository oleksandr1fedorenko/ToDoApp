﻿namespace TodoAppBe.DTO;

public class TTaskDto
{
    public Guid PublicId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
}