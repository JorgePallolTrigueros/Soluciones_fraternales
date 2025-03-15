class ModalManager {
    constructor() {
        console.log('ModalManager constructor');
        this.modalContainer = document.getElementById('modal-container');
        this.modalContent = document.getElementById('modal-content');
    }

    openModal(config) {
        const { tipo, datosModal, accion, fields } = config;
        const url = `${tipo}`;

        fetch(url)
            .then(response => response.text())
            .then(data => {
                this.modalContent.innerHTML = data;
                this.modalContainer.style.display = 'flex';
                console.log('Deberia verse el modal');

                // Verificar si existen datos y campos antes de poblar el modal
                if (datosModal && fields && Array.isArray(fields)) {
                    this.populateModal(fields, datosModal);
                }

                this.executeScripts();
            })
            .catch(error => {
                console.error('Error al cargar el contenido del modal:', error);
                this.modalContent.innerHTML = '<p>Error al cargar el contenido del modal.</p>';
            });
    }

    executeScripts() {
        const scripts = this.modalContent.querySelectorAll('script');
        scripts.forEach(script => {
            const newScript = document.createElement('script');
            if (script.src) {
                newScript.src = script.src;
            } else {
                newScript.textContent = script.textContent;
            }
            document.body.appendChild(newScript);
            document.body.removeChild(newScript); // Optionally remove the script after execution
        });
    }

    populateModal(fields, datosModal) {
        fields.forEach(field => {
            const element = document.getElementById(field.id);
            if (element) {
                element.value = datosModal[field.key] || ''; // Use empty string if undefined
            }
        });
    }

    closeModal() {
        this.modalContainer.style.display = 'none';
        this.modalContent.innerHTML = ''; // Clear the modal content on close
    }
}

// Optionally export ModalManager if you are using modules
// export default ModalManager;