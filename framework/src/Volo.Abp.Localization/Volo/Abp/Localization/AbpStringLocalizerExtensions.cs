﻿using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Extensions.Localization;
using Volo.Abp.DynamicProxy;
using Volo.Abp.Reflection;

namespace Volo.Abp.Localization;

public static class AbpStringLocalizerExtensions
{
    [NotNull]
    public static IStringLocalizer GetInternalLocalizer(
        [NotNull] this IStringLocalizer stringLocalizer)
    {
        Check.NotNull(stringLocalizer, nameof(stringLocalizer));

        var localizerType = stringLocalizer.GetType();
        if (!ReflectionHelper.IsAssignableToGenericType(localizerType, typeof(StringLocalizer<>)))
        {
            return stringLocalizer;
        }

        var localizerField = localizerType
            .GetField(
                "_localizer",
                BindingFlags.Instance |
                BindingFlags.NonPublic
            );

        if (localizerField == null)
        {
            throw new AbpException($"Could not find the _localizer field inside the {typeof(StringLocalizer<>).FullName} class. Probably its name has changed. Please report this issue to the ABP framework.");
        }

        return localizerField.GetValue(stringLocalizer) as IStringLocalizer;
    }

    public static IEnumerable<LocalizedString> GetAllStrings(
        this IStringLocalizer stringLocalizer,
        bool includeParentCultures,
        bool includeBaseLocalizers)
    {
        var internalLocalizer = ((IStringLocalizer)ProxyHelper.UnProxy(stringLocalizer)).GetInternalLocalizer();
        if (internalLocalizer is IAbpStringLocalizer abpStringLocalizer)
        {
            return abpStringLocalizer.GetAllStrings(
                includeParentCultures,
                includeBaseLocalizers
            );
        }

        return stringLocalizer.GetAllStrings(
            includeParentCultures
        );
    }

    public static IEnumerable<string> GetSupportedCultures(this IStringLocalizer localizer)
    {
        var internalLocalizer = ((IStringLocalizer)ProxyHelper.UnProxy(localizer)).GetInternalLocalizer();
        if (internalLocalizer is IAbpStringLocalizer abpStringLocalizer)
        {
            return abpStringLocalizer.GetSupportedCultures();
        }

        return Array.Empty<string>();
    }
}
