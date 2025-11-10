
1. Todo código desenvolvido é integrado na main.
2. Após definido features do próximo pacote, é iniciada a branch release/x.x.x
3. 


Branchs:

- `main`: Pode conter código instável.
- `release/x.x.x`:
  - Estabilização da versão.
  - Alteração da tag `VersionPrefix`.
  - CI para publicar versão preview.
- PR `main <- release/x.x.x`:
  - Inicia CI para publicar versão oficial Nuget.
  - Autotag com versão publicada.
