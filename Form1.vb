Imports cd_conexion

Public Class Form1

    Dim CRUD As New Class1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.DataSource = CRUD.ListarEmpleados

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        lblCodigo.Text = DataGridView1.Item(0, e.RowIndex).Value
        txtNombre.Text = DataGridView1.Item(1, e.RowIndex).Value
        txtDireccion.Text = DataGridView1.Item(2, e.RowIndex).Value
        DateTimePicker1.Text = DataGridView1.Item(3, e.RowIndex).Value
        DateTimePicker2.Text = DataGridView1.Item(4, e.RowIndex).Value
        txtArea.Text = DataGridView1.Item(5, e.RowIndex).Value

    End Sub

    Private Sub RegistrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem.Click

        Try
            CRUD.Insertar(txtNombre.Text, txtDireccion.Text, (CDate(DateTimePicker1.Text)), (CDate(DateTimePicker2.Text)), txtArea.Text)
            DataGridView1.DataSource = CRUD.ListarEmpleados
            MsgBox("Se registro correctamente al usuario: " + txtNombre.Text)

            txtNombre.Text = ""
            txtDireccion.Text = ""
            txtArea.Text = ""
            lblCodigo.Text = "g0000"
            DateTimePicker1.Value = DateTime.Now
            DateTimePicker2.Value = DateTime.Now

        Catch ex As Exception
            MsgBox("404 NO SE PUEDE INSERTAR")
        End Try


    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        Try
            CRUD.Modificar(lblCodigo.Text, txtNombre.Text, txtDireccion.Text, (CDate(DateTimePicker1.Text)), (CDate(DateTimePicker2.Text)), txtArea.Text)
            DataGridView1.DataSource = CRUD.ListarEmpleados
            MsgBox("Se Modifico correctamente al usuario con codigo: " + lblCodigo.Text)

            txtNombre.Text = ""
            txtDireccion.Text = ""
            txtArea.Text = ""
            lblCodigo.Text = "g0000"
            DateTimePicker1.Value = DateTime.Now
            DateTimePicker2.Value = DateTime.Now

        Catch ex As Exception
            MsgBox("404 NO SE PUEDE MODIFICAR")
        End Try
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Try
            CRUD.Eliminar(lblCodigo.Text)
            DataGridView1.DataSource = CRUD.ListarEmpleados
            MsgBox("Se ELIMINO correctamente al usuario con codigo: " + lblCodigo.Text)

            txtNombre.Text = ""
            txtDireccion.Text = ""
            txtArea.Text = ""
            lblCodigo.Text = "g0000"
            DateTimePicker1.Value = DateTime.Now
            DateTimePicker2.Value = DateTime.Now

        Catch ex As Exception
            MsgBox("404 NO SE PUEDE ELIMINAR")
        End Try
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        txtNombre.Text = ""
        txtDireccion.Text = ""
        txtArea.Text = ""
        lblCodigo.Text = "g0000"
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now


    End Sub
End Class
