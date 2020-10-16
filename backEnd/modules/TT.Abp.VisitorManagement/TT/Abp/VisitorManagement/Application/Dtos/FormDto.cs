using System;
using System.Collections.Generic;

namespace TT.Abp.VisitorManagement.Application.Dtos
{
    public class FormDto
    {
        private FormDto()
        {
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public VisitorEnums.FormTheme Theme { get; set; }

        public List<FormItemDto> FormItems { get; set; }
    }


    public class FormCreateOrEditDto
    {
        private FormCreateOrEditDto()
        {
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public VisitorEnums.FormTheme Theme { get; set; }

        public List<FormItemCreateOrEditDto> FormItems { get; set; }
    }


    public class FormItemDto
    {
        private FormItemDto()
        {
        }

        public VisitorEnums.FormItemType Type { get; set; }
        public int Sort { get; set; }
        public string Label { get; set; }
        public string Key { get; set; }
        public string PlaceHolder { get; set; }
        public string DefaultValue { get; set; }
        public string ErrorText { get; set; }
        public bool IsRequired { get; set; }
        public bool IsDisable { get; set; }
        public bool IsMulti { get; set; }
        public bool SaveToLocal { get; set; }


        //only in dto
        public string Value { get; set; }
        public List<SelectionItem> Selections { get; set; }
    }

    public class FormItemCreateOrEditDto
    {
        private FormItemCreateOrEditDto()
        {
        }

        public Guid ItemId { get; }
        public Guid FormId { get; }
        public VisitorEnums.FormItemType Type { get; set; }
        public int Sort { get; set; }
        public string Label { get; set; }
        public string Key { get; set; }
        public string PlaceHolder { get; set; }
        public string DefaultValue { get; set; }
        public string ErrorText { get; set; }
        public bool IsRequired { get; set; }
        public bool IsDisable { get; set; }
        public bool IsMulti { get; set; }
        public bool SaveToLocal { get; set; }


        public List<SelectionItem> Selections { get; set; }
    }


    public class SelectionItem
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public bool IsChecked { get; set; } = false;
    }
}