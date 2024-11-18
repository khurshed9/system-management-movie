using SystemManagementMovie.Common.Base;

namespace SystemManagementMovie.Moduls.UserIdentity.Filters;

public record UserFilter(bool? HasPremium) : BaseFilter;