using System;
using JetBrains.Annotations;

namespace crm_tgui.Dto;

public record CustomerBaseDto(
    string FirstName,
    string MiddleName,
    string LastName,
    string NationalId
);