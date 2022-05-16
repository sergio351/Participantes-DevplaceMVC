@ModelType IEnumerable(Of Participantes__DevPlace.Participantes)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Participantes</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.edad)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.edad)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.idParticipante }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.idParticipante }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.idParticipante })
        </td>
    </tr>
Next

</table>
