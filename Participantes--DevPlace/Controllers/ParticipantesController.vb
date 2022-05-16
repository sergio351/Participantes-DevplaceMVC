Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Participantes__DevPlace

Namespace Controllers
    Public Class ParticipantesController
        Inherits System.Web.Mvc.Controller

        Private db As New ParticipantesDevPlaceEntities

        ' GET: Participantes
        Function Index() As ActionResult
            Return View(db.Participantes.ToList())
        End Function

        ' GET: Participantes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim participantes As Participantes = db.Participantes.Find(id)
            If IsNothing(participantes) Then
                Return HttpNotFound()
            End If
            Return View(participantes)
        End Function

        ' GET: Participantes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Participantes/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="idParticipante,nombre,edad")> ByVal participantes As Participantes) As ActionResult
            If ModelState.IsValid Then
                db.Participantes.Add(participantes)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(participantes)
        End Function

        ' GET: Participantes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim participantes As Participantes = db.Participantes.Find(id)
            If IsNothing(participantes) Then
                Return HttpNotFound()
            End If
            Return View(participantes)
        End Function

        ' POST: Participantes/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="idParticipante,nombre,edad")> ByVal participantes As Participantes) As ActionResult
            If ModelState.IsValid Then
                db.Entry(participantes).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(participantes)
        End Function

        ' GET: Participantes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim participantes As Participantes = db.Participantes.Find(id)
            If IsNothing(participantes) Then
                Return HttpNotFound()
            End If
            Return View(participantes)
        End Function

        ' POST: Participantes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim participantes As Participantes = db.Participantes.Find(id)
            db.Participantes.Remove(participantes)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
                End Ifpp
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
