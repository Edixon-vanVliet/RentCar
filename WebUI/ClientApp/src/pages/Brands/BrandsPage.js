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
export const BrandsPage = () => {
  const [brands, setBrands] = useState([]);
  const [modal, setModal] = useState(false);
  const [formData, setFormData] = useState({ id: 0, name: "", description: "" });

  const toggle = () => {
    setModal(!modal);
    setFormData({ id: 0, name: "", description: "" });
  };

  const handleSave = async () => {
    toggle();

    if (formData.id !== 0) {
      const updatedItems = brands.map((brand) => {
        if (brand.id === formData.id) {
          return formData;
        }

        return brand;
      });

      setBrands(updatedItems);

      await apiService.put(`/api/brands/${formData.id}`, formData);
    } else {
      var response = await apiService.post(`/api/brands`, formData);

      setBrands([...brands, response.data]);
    }
  };

  const handleEdit = (brand) => {
    toggle();
    setFormData(brand);
  };

  const handleDelete = async (id) => {
    Swal.fire({
      title: "¿Estás seguro?",
      text: "¿Estás seguro de que deseas eliminar esta marca?",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Sí, eliminar",
      cancelButtonText: "Cancelar",
    }).then(async (result) => {
      if (result.isConfirmed) {
        Swal.showLoading();
        const updatedItems = brands.filter((brand) => brand.id !== id);
        setBrands(updatedItems);
        await apiService.delete(`/api/brands/${id}`);

        Swal.fire("Eliminado", "La marca ha sido eliminada.", "success");
      }
    });
  };

  useEffect(() => {
    const fetchData = async () => {
      const response = await apiService.get("/api/brands");
      setBrands(response.data);
    };

    fetchData();
  }, []);

  return (
    <Container>
      <h2>Marcas</h2>

      <Button color="success" className="float-end" onClick={toggle}>
        Agregar marca
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
          {!brands.length ? (
            <tr>
              <td colSpan={3} style={{ textAlign: "center" }}>
                No hay Data
              </td>
            </tr>
          ) : (
            brands.map((brand) => (
              <tr key={brand.id}>
                <td>{brand.name}</td>
                <td>{brand.description}</td>
                <td>
                  <Button color="warning" onClick={() => handleEdit(brand)}>
                    Editar
                  </Button>{" "}
                  <Button color="danger" onClick={() => handleDelete(brand.id)}>
                    Eliminar
                  </Button>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </Table>
      <Modal isOpen={modal} toggle={toggle}>
        <ModalHeader toggle={toggle}>{formData.id !== 0 ? "Editar marca" : "Agregar marca"}</ModalHeader>
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
