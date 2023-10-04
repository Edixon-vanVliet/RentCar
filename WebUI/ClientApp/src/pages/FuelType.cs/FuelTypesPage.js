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
export const FuelTypesPage = () => {
  const [fuelTypes, setFuelTypes] = useState([]);
  const [modal, setModal] = useState(false);
  const [formData, setFormData] = useState({ id: 0, name: "", description: "" });

  const toggle = () => {
    setModal(!modal);
    setFormData({ id: 0, name: "", description: "" });
  };

  const handleSave = async () => {
    toggle();

    if (formData.id !== 0) {
      const updatedItems = fuelTypes.map((fuelType) => {
        if (fuelType.id === formData.id) {
          return formData;
        }

        return fuelType;
      });

      setFuelTypes(updatedItems);

      await apiService.put(`/api/fuelTypes/${formData.id}`, formData);
    } else {
      var response = await apiService.post(`/api/fuelTypes`, formData);

      setFuelTypes([...fuelTypes, response.data]);
    }
  };

  const handleEdit = (fuelType) => {
    toggle();
    setFormData(fuelType);
  };

  const handleDelete = async (id) => {
    Swal.fire({
      title: "¿Estás seguro?",
      text: "¿Estás seguro de que deseas eliminar esta tipo de combustible?",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Sí, eliminar",
      cancelButtonText: "Cancelar",
    }).then(async (result) => {
      if (result.isConfirmed) {
        Swal.showLoading();
        const updatedItems = fuelTypes.filter((fuelType) => fuelType.id !== id);
        setFuelTypes(updatedItems);
        await apiService.delete(`/api/fuelTypes/${id}`);

        Swal.fire("Eliminado", "El tipo de combustible ha sido eliminada.", "success");
      }
    });
  };

  useEffect(() => {
    const fetchData = async () => {
      const response = await apiService.get("/api/fuelTypes");
      setFuelTypes(response.data);
    };

    fetchData();
  }, []);

  return (
    <Container>
      <h2>Tipos de Combustible</h2>

      <Button color="success" className="float-end" onClick={toggle}>
        Agregar tipo de combustible
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
          {!fuelTypes.length ? (
            <tr>
              <td colSpan={3} style={{ textAlign: "center" }}>
                No hay Data
              </td>
            </tr>
          ) : (
            fuelTypes.map((fuelType) => (
              <tr key={fuelType.id}>
                <td>{fuelType.name}</td>
                <td>{fuelType.description}</td>
                <td>
                  <Button color="warning" onClick={() => handleEdit(fuelType)}>
                    Editar
                  </Button>{" "}
                  <Button color="danger" onClick={() => handleDelete(fuelType.id)}>
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
          {formData.id !== 0 ? "Editar tipo de combustible" : "Agregar tipo de combustible"}
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
