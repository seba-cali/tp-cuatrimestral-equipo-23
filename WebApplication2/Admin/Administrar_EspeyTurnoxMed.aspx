<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Panel.master" AutoEventWireup="true" CodeBehind="Administrar_EspeyTurnoxMed.aspx.cs" Inherits="WebApplication2.Admin.Administrar_EspeyTurnoxMed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="layoutSidenav_content">
        <main>
            <h2 class="text-center">Administración de Turnos de trabajo y especialidades</h2>
            <div class="container">
                <div class="row align-items-center justify-content-between pt-3">
                    <div class="col-auto mb-3"></div>
                </div>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="text-center">
                            <asp:Label ID="lblMedico" Text="" Style="color: darkslategrey; font-weight: bold;" runat="server" />
                        </div>
                        <div class="text-center">
                            <asp:Label ID="lblMatricula" Text="" Style="color: dimgrey; font-weight: bold;" runat="server" />
                        </div>
                        <div class="text-center">
                            <asp:Label ID="lblMsje" Text="" Style="color: red; font-weight: bold;" runat="server" />
                            <asp:Label ID="lblmsg" Text="" Style="color: black; font-weight: bold;" runat="server" />
                        </div>

                        <div class="row">
                            <div class="col-3">
                                <div class="mb-3">
                                    <asp:Label Text="Especialidad" ID="ddlEspecialidad" runat="server"></asp:Label>
                                    <asp:DropDownList ID="filtroEspecialidad" runat="server" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>


                                </div>

                            </div>

                        </div>

                        <br />
                        <div class="table-responsive">
                            <asp:GridView ID="dgvEspecialidadxTurno" runat="server" CssClass="table table-striped table-bordered table-sm mx-auto" AutoGenerateColumns="false">
                                <HeaderStyle HorizontalAlign="Center" />
                                <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField HeaderText="ID Medico" DataField="ID_MEDICO" />
                                    <asp:BoundField HeaderText="Medico" DataField="Name" />
                                    <asp:BoundField HeaderText="ID Especialidad" DataField="ID_ESPECIALIDAD" />
                                    <asp:BoundField HeaderText="Especialidad" DataField="ESPECIALIDAD" />
                                    <asp:BoundField HeaderText="TurnoOriginal" DataField="Turno_Horario" />
                                    <asp:TemplateField HeaderText="Turno">
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="rblTurnos" runat="server" SelectedValue='<%# Eval("turno_horario") %>' OnSelectedIndexChanged="rblTurnos_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Text="Mañana" Value="0" />
                                                <asp:ListItem Text="Tarde" Value="1" />
                                                <asp:ListItem Text="Noche" Value="2" />
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Lunes">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbLunes" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("Atiende_Lunes") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Martes">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbMartes" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("Atiende_Martes") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Miercoles">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbMiercoles" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("Atiende_Miercoles") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jueves">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbJueves" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("Atiende_Jueves") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Viernes">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbViernes" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("Atiende_Viernes") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sabado">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbSabado" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("Atiende_Sabado") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Domingo">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbDomingo" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("Atiende_Domingo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm" Text="🗑" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("ID_MEDICO") + "," + Eval("ID_ESPECIALIDAD") + "," + Eval("Turno_Horario") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <br />
                        <div class="d-flex justify-content-center">
                            <button class="btn btn-secondary" type="button" data-bs-toggle="modal" data-bs-target="#createGroupModal">
                                <i class="me-1" data-feather="plus"></i>
                                Crear Nueva Especialidad y Turno por Medico
                            </button>
                            
                        </div>
                        <div class="d-flex justify-content-center mt-3">
                            <asp:Button class="btn btn-danger" runat="server" Text="Volver" type="button" ID="btnVolver" OnClick="btnVolver_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="createGroupModal" tabindex="-1" role="dialog" aria-labelledby="createGroupModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="createGroupModal1">Crear Especialidad y Turno por Medico</h5>
                            <button class="btn-close" type="button" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div class="mb-0">
                                <div class="mb-0">
                                    <label class="mb-1 small text-muted" for="formGroupName">Medico</label>
                                    <asp:DropDownList ID="inputMedico" runat="server" CssClass="form-control" AutoPostBack="false" Enabled="false"></asp:DropDownList>
                                </div>
                                <div class="mb-0">
                                    <label class="mb-1 small text-muted" for="formGroupDesc">Especialidad</label>
                                    <asp:DropDownList ID="inputEspecialidad" runat="server" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                                </div>
                                <div class="mb-0">
                                    <label class="mb-1 small text-muted" for="formGroupURL">Turno</label>
                                    <asp:DropDownList ID="inputTurno" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Turno de Trabajo" Value="" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Mañana" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Tarde" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Noche" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-danger-soft text-danger" type="button" data-bs-dismiss="modal">Cerrar</button>
                            <asp:Button ID="Ingresar" CausesValidation="False" runat="server" Text="Crear Relacion" CssClass="btn btn-primary-soft text-primary" OnClick="Ingresar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </main>
    </div>
</asp:Content>
