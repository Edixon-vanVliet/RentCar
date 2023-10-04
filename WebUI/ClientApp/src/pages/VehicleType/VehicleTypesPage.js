import { useEffect, useState } from "react";
import Swal from "sweetalert2";
import apiService from "../../services/apiService";
import {
  Button,
  Container,
  Form,
  FormGroup,
  Input,
  Label,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Table,
} from "reactstrap";
export const VehicleTypesPage = () => {
  const [vehicleTypes, setVehicleTypes] = useState([]);
  const [modal, setModal] = useState(false);
  const [formData, setFormData] = useState({ id: 0, name: "", description: "" });

  const toggle = () => {
    setModal(!modal);
    setFormData({ id: 0, name: "", description: "" });
  };

  const handleSave = async () => {
    toggle();

    if (formData.id !== 0) {
      const updatedItems = vehicleTypes.map((vehicleType) => {
        if (vehicleType.id === formData.id) {
          return formData;
        }

        return vehicleType;
      });

      setVehicleTypes(updatedItems);

      await apiService.put(`/api/vehicleTypes/${formData.id}`, formData);
    } else {
      var response = await apiService.post(`/api/vehicleTypes`, formData);

      setVehicleTypes([...vehicleTypes, response.data]);
    }
  };

  const handleEdit = (vehicleType) => {
    toggle();
    setFormData(vehicleType);
  };

  const handleDelete = async (id) => {
    Swal.fire({
      title: "¿Estás seguro?",
      text: "¿Estás seguro de que deseas eliminar esta tipo de vehiculo?",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Sí, eliminar",
      cancelButtonText: "Cancelar",
    }).then(async (result) => {
      if (result.isConfirmed) {
        Swal.showLoading();
        const updatedItems = vehicleTypes.filter((vehicleType) => vehicleType.id !== id);
        setVehicleTypes(updatedItems);
        await apiService.delete(`/api/vehicleTypes/${id}`);

        Swal.fire("Eliminado", "El tipo de vehiculo ha sido eliminada.", "success");
      }
    });
  };

  useEffect(() => {
    const fetchData = async () => {
      const response = await apiService.get("/api/vehicleTypes");
      setVehicleTypes(response.data);
    };

    fetchData();
  }, []);

  return (
    <Container>
      <h2>Tipos de Vehiculo</h2>

      <Button color="success" className="float-end" onClick={toggle}>
        Agregar tipo de vehiculo
      </Button>
      <Table striped>
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Descripción</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {!vehicleTypes.length ? (
            <tr>
              <td colSpan={3} style={{ textAlign: "center" }}>
                No hay Data
              </td>
            </tr>
          ) : (
            vehicleTypes.map((vehicleType) => (
              <tr key={vehicleType.id}>
                <td>{vehicleType.name}</td>
                <td>{vehicleType.description}</td>
                <td>
                  <Button color="warning" onClick={() => handleEdit(vehicleType)}>
                    Editar
                  </Button>{" "}
                  <Button color="danger" onClick={() => handleDelete(vehicleType.id)}>
                    Eliminar
                  </Button>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </Table>
      <Modal isOpen={modal} toggle={toggle}>
        <ModalHeader toggle={toggle}>
          {formData.id !== 0 ? "Editar tipo de vehiculo" : "Agregar tipo de vehiculo"}
        </ModalHeader>
        <ModalBody>
          <Form>
            <FormGroup>
              <Label for="name">Nombre</Label>
              <Input
                type="text"
                id="name"
                value={formData.name}
                onChange={(e) => setFormData({ ...formData, name: e.target.value })}
              />
            </FormGroup>
            <FormGroup>
              <Label for="description">Descripción</Label>
              <Input
                type="textarea"
                id="description"
                value={formData.description}
                onChange={(e) => setFormData({ ...formData, description: e.target.value })}
              />
            </FormGroup>
          </Form>
        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={handleSave}>
            Guardar
          </Button>{" "}
          <Button color="secondary" onClick={toggle}>
            Cancelar
          </Button>
        </ModalFooter>
      </Modal>
    </Container>
  );
};
